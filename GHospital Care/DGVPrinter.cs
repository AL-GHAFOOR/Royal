using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GHospital_Care
{
    #region Supporting Classes


    /// </summary>
    public class DGVCellDrawingEventArgs : EventArgs
    {
        public Graphics g;
        public RectangleF DrawingBounds;
        public DataGridViewCellStyle CellStyle;
        public int row;
        public int column;
        public Boolean Handled;

        public DGVCellDrawingEventArgs(Graphics g, RectangleF bounds, DataGridViewCellStyle style,
            int row, int column)
            : base()
        {
            this.g = g;
            DrawingBounds = bounds;
            CellStyle = style;
            this.row = row;
            this.column = column;
            Handled = false;
        }
    }


    public delegate void CellOwnerDrawEventHandler(object sender, DGVCellDrawingEventArgs e);


    public static class Extensions
    {
        /// <summary>
        /// Extension method to print all the "ImbeddedImages" in a provided list
        /// </summary>
        /// <typeparam name="?"></typeparam>
        /// <param name="list"></param>
        /// <param name="g"></param>
        /// <param name="pagewidth"></param>
        /// <param name="pageheight"></param>
        /// <param name="margins"></param>
        public static void DrawImbeddedImage<T>(this IEnumerable<T> list,
            Graphics g, int pagewidth, int pageheight, Margins margins)
        {
            foreach (T t in list)
            {
                if (t.GetType() == typeof(DGVPrinter.ImbeddedImage))
                {
                    DGVPrinter.ImbeddedImage ii = (DGVPrinter.ImbeddedImage)Convert.ChangeType(t, typeof(DGVPrinter.ImbeddedImage));
                    g.DrawImageUnscaled(ii.theImage, ii.upperleft(pagewidth, pageheight, margins));
                }
            }
        }

    }

    #endregion

    /// <summary>

    /// </summary>
    public class DGVPrinter
    {
        public enum Alignment { NotSet, Left, Right, Center }
        public enum Location { Header, Footer, Absolute }


        public class ImbeddedImage
        {
            public Image theImage { get; set; }
            public Alignment ImageAlignment { get; set; }
            public Location ImageLocation { get; set; }
            public Int32 ImageX { get; set; }
            public Int32 ImageY { get; set; }

            internal Point upperleft(int pagewidth, int pageheight, Margins margins)
            {
                int y = 0;
                int x = 0;


                if (ImageLocation == Location.Absolute)
                    return new Point(ImageX, ImageY);


                switch (ImageLocation)
                {
                    case Location.Header:
                        y = margins.Top;
                        break;
                    case Location.Footer:
                        y = pageheight - theImage.Height - margins.Bottom;
                        break;
                    default:
                        throw new ArgumentException(String.Format("Unkown value: {0}", ImageLocation));
                }


                switch (ImageAlignment)
                {
                    case Alignment.Left:
                        x = margins.Left;
                        break;
                    case Alignment.Center:
                        x = (int)(pagewidth / 2 - theImage.Width / 2) + margins.Left;
                        break;
                    case Alignment.Right:
                        x = (int)(pagewidth - theImage.Width) + margins.Left;
                        break;
                    case Alignment.NotSet:
                        x = ImageX;
                        break;
                    default:
                        throw new ArgumentException(String.Format("Unkown value: {0}", ImageAlignment));
                }

                return new Point(x, y);
            }
        }

        public IList<ImbeddedImage> ImbeddedImageList = new List<ImbeddedImage>();


        class PageDef
        {
            public PageDef(Margins m, int count)
            {
                colstoprint = new List<object>(count);
                colwidths = new List<float>(count);
                colwidthsoverride = new List<float>(count);
                coltotalwidth = 0;
                margins = (Margins)m.Clone();
            }

            public IList colstoprint;
            public List<float> colwidths;
            public List<float> colwidthsoverride;
            public float coltotalwidth;
            public Margins margins;
        }
        IList<PageDef> pagesets;
        int currentpageset = 0;


        public class PrintDialogSettingsClass
        {
            public bool AllowSelection = true;
            public bool AllowSomePages = true;
            public bool AllowCurrentPage = true;
            public bool AllowPrintToFile = false;
            public bool ShowHelp = true;
            public bool ShowNetwork = true;
            public bool UseEXDialog = true;
        }



        #region global variables

        // the data grid view we're printing
        DataGridView dgv = null;

        // print document
        PrintDocument printDoc = null;

        // print status items
        IList rowstoprint;
        IList colstoprint;          // divided into pagesets for printing
        int lastrowprinted = -1;
        int currentrow = -1;
        int fromPage = 0;
        int toPage = -1;
        const int maxPages = 2147483647;

        // page formatting options
        int pageHeight = 0;
        float staticheight = 0;
        float rowstartlocation = 0;
        int pageWidth = 0;
        int printWidth = 0;
        float rowheaderwidth = 0;
        int CurrentPage = 0;
        PrintRange printRange;

        // calculated values
        private float headerHeight = 0;
        private float footerHeight = 0;
        private float pagenumberHeight = 0;
        private float colheaderheight = 0;
        private List<float> rowheights;
        private List<float> colwidths;
        #endregion


        #region properties

        #region global properties

        /// <summary>
        /// OwnerDraw Event declaration. Callers can subscribe to this event to override the 
        /// cell drawing.
        /// </summary>
        public event CellOwnerDrawEventHandler OwnerDraw;

        /// <summary>
        /// provide an override for the print preview dialog "owner" field
        /// Note: Changed style for VS2005 compatibility
        /// </summary>
        //public Form Owner
        //{ get; set; }
        protected Form _Owner = null;
        public Form Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }

        /// <summary>
        /// provide an override for the print preview zoom setting
        /// Note: Changed style for VS2005 compatibility
        /// </summary>
        //public Double PrintPreviewZoom
        //{ get; set; }
        protected Double _PrintPreviewZoom = 1.0;
        public Double PrintPreviewZoom
        {
            get { return _PrintPreviewZoom; }
            set { _PrintPreviewZoom = value; }
        }


        /// <summary>
        /// expose printer settings to allow access to calling program
        /// </summary>
        public PrinterSettings PrintSettings
        {
            get { return printDoc.PrinterSettings; }
        }

        /// <summary>
        /// expose settings for the PrintDialog displayed to the user
        /// </summary>
        private PrintDialogSettingsClass printDialogSettings = new PrintDialogSettingsClass();
        public PrintDialogSettingsClass PrintDialogSettings
        {
            get { return printDialogSettings; }
        }

        /// <summary>
        /// Set Printer Name
        /// </summary>
        private String printerName;
        public String PrinterName
        {
            get { return printerName; }
            set { printerName = value; }
        }

        /// <summary>
        /// Allow access to the underlying print document
        /// </summary>
        public PrintDocument printDocument
        {
            get { return printDoc; }
            set { printDoc = value; }
        }

        /// <summary>
        /// Allow caller to set the upper-left corner icon used
        /// in the print preview dialog
        /// </summary>
        private Icon ppvIcon = null;
        public Icon PreviewDialogIcon
        {
            get { return ppvIcon; }
            set { ppvIcon = value; }
        }

        /// <summary>
        /// Flag to control whether or not we print the Page Header
        /// </summary>
        private Boolean printHeader = true;
        public Boolean PrintHeader
        {
            get { return printHeader; }
            set { printHeader = value; }
        }

        /// <summary>
        /// Flag to control whether or not we print the Page Footer
        /// </summary>
        private Boolean printFooter = true;
        public Boolean PrintFooter
        {
            get { return printFooter; }
            set { printFooter = value; }
        }

        /// <summary>
        /// Flag to control whether or not we print the Column Header line
        /// </summary>
        private Boolean? printColumnHeaders;
        public Boolean? PrintColumnHeaders
        {
            get { return printColumnHeaders; }
            set { printColumnHeaders = value; }
        }

        /// <summary>
        /// Flag to control whether or not we print the Column Header line
        /// Defaults to False to match previous functionality
        /// </summary>
        private Boolean? printRowHeaders = false;
        public Boolean? PrintRowHeaders
        {
            get { return printRowHeaders; }
            set { printRowHeaders = value; }
        }

        /// <summary>
        /// Flag to control whether rows are printed whole or if partial
        /// rows should be printed to fill the bottom of the page. Turn this
        /// "Off" (i.e. false) to print cells/rows deeper than one page
        /// </summary>
        private Boolean keepRowsTogether = true;
        public Boolean KeepRowsTogether
        {
            get { return keepRowsTogether; }
            set { keepRowsTogether = value; }
        }

        #endregion

        // Title
        #region title properties

        // override flag
        bool overridetitleformat = false;

        /// <summary>
        /// Title for this report. Default is empty.
        /// </summary>
        private String title;
        public String Title
        {
            get { return title; }
            set
            {
                title = value;
                if (docName == null)
                {
                    printDoc.DocumentName = value;
                }
            }
        }

        /// <summary>
        /// Name of the document. Default is report title (can be empty)
        /// </summary>
        private String docName;
        public String DocName
        {
            get { return docName; }
            set { printDoc.DocumentName = value; docName = value; }
        }

        /// <summary>
        /// Font for the title. Default is Tahoma, 18pt.
        /// </summary>
        private Font titlefont;
        public Font TitleFont
        {
            get { return titlefont; }
            set { titlefont = value; }
        }

        /// <summary>
        /// Foreground color for the title. Default is Black
        /// </summary>
        private Color titlecolor;
        public Color TitleColor
        {
            get { return titlecolor; }
            set { titlecolor = value; }
        }

        /// <summary>
        /// Allow override of the header cell format object
        /// </summary>
        private StringFormat titleformat;
        public StringFormat TitleFormat
        {
            get { return titleformat; }
            set { titleformat = value; overridetitleformat = true; }
        }

        /// <summary>
        /// Allow the user to override the title string alignment. Default value is 
        /// Alignment - Near; 
        /// </summary>
        public StringAlignment TitleAlignment
        {
            get { return titleformat.Alignment; }
            set
            {
                titleformat.Alignment = value;
                overridetitleformat = true;
            }
        }

        /// <summary>
        /// Allow the user to override the title string format flags. Default values
        /// are: FormatFlags - NoWrap, LineLimit, NoClip
        /// </summary>
        public StringFormatFlags TitleFormatFlags
        {
            get { return titleformat.FormatFlags; }
            set
            {
                titleformat.FormatFlags = value;
                overridetitleformat = true;
            }
        }

        /// <summary>
        /// Mandatory spacing between the grid and the footer
        /// </summary>
        private float titlespacing;
        public float TitleSpacing
        {
            get { return titlespacing; }
            set { titlespacing = value; }
        }

        #endregion

        // SubTitle
        #region subtitle properties

        // override flat
        bool overridesubtitleformat = false;

        /// <summary>
        /// SubTitle for this report. Default is empty.
        /// </summary>
        private String subtitle;
        public String SubTitle
        {
            get { return subtitle; }
            set { subtitle = value; }
        }

        /// <summary>
        /// Font for the subtitle. Default is Tahoma, 12pt.
        /// </summary>
        private Font subtitlefont;
        public Font SubTitleFont
        {
            get { return subtitlefont; }
            set { subtitlefont = value; }
        }

        /// <summary>
        /// Foreground color for the subtitle. Default is Black
        /// </summary>
        private Color subtitlecolor;
        public Color SubTitleColor
        {
            get { return subtitlecolor; }
            set { subtitlecolor = value; }
        }

        /// <summary>
        /// Allow override of the header cell format object
        /// </summary>
        private StringFormat subtitleformat;
        public StringFormat SubTitleFormat
        {
            get { return subtitleformat; }
            set { subtitleformat = value; overridesubtitleformat = true; }
        }

        /// <summary>
        /// Allow the user to override the subtitle string alignment. Default value is 
        /// Alignment - Near; 
        /// </summary>
        public StringAlignment SubTitleAlignment
        {
            get { return subtitleformat.Alignment; }
            set
            {
                subtitleformat.Alignment = value;
                overridesubtitleformat = true;
            }
        }

        /// <summary>
        /// Allow the user to override the subtitle string format flags. Default values
        /// are: FormatFlags - NoWrap, LineLimit, NoClip
        /// </summary>
        public StringFormatFlags SubTitleFormatFlags
        {
            get { return subtitleformat.FormatFlags; }
            set
            {
                subtitleformat.FormatFlags = value;
                overridesubtitleformat = true;
            }
        }

        /// <summary>
        /// Mandatory spacing between the grid and the footer
        /// </summary>
        private float subtitlespacing;
        public float SubTitleSpacing
        {
            get { return subtitlespacing; }
            set { subtitlespacing = value; }
        }
        #endregion

        // Footer
        #region footer properties

        // override flag
        bool overridefooterformat = false;

        /// <summary>
        /// footer for this report. Default is empty.
        /// </summary>
        private String footer;
        public String Footer
        {
            get { return footer; }
            set { footer = value; }
        }

        /// <summary>
        /// Font for the footer. Default is Tahoma, 10pt.
        /// </summary>
        private Font footerfont;
        public Font FooterFont
        {
            get { return footerfont; }
            set { footerfont = value; }
        }

        /// <summary>
        /// Foreground color for the footer. Default is Black
        /// </summary>
        private Color footercolor;
        public Color FooterColor
        {
            get { return footercolor; }
            set { footercolor = value; }
        }

        /// <summary>
        /// Allow override of the header cell format object
        /// </summary>
        private StringFormat footerformat;
        public StringFormat FooterFormat
        {
            get { return footerformat; }
            set { footerformat = value; overridefooterformat = true; }
        }

        /// <summary>
        /// Allow the user to override the footer string alignment. Default value is 
        /// Alignment - Center; 
        /// </summary>
        public StringAlignment FooterAlignment
        {
            get { return footerformat.Alignment; }
            set
            {
                footerformat.Alignment = value;
                overridefooterformat = true;
            }
        }

        /// <summary>
        /// Allow the user to override the footer string format flags. Default values
        /// are: FormatFlags - NoWrap, LineLimit, NoClip
        /// </summary>
        public StringFormatFlags FooterFormatFlags
        {
            get { return footerformat.FormatFlags; }
            set
            {
                footerformat.FormatFlags = value;
                overridefooterformat = true;
            }
        }

        /// <summary>
        /// Mandatory spacing between the grid and the footer
        /// </summary>
        private float footerspacing;
        public float FooterSpacing
        {
            get { return footerspacing; }
            set { footerspacing = value; }
        }

        #endregion

        // Page Numbering
        #region page number properties

        // override flag
        bool overridepagenumberformat = false;

        /// <summary>
        /// Include page number in the printout. Default is true.
        /// </summary>
        private bool pageno = true;
        public bool PageNumbers
        {
            get { return pageno; }
            set { pageno = value; }
        }

        /// <summary>
        /// Font for the page number, Default is Tahoma, 8pt.
        /// </summary>
        private Font pagenofont;
        public Font PageNumberFont
        {
            get { return pagenofont; }
            set { pagenofont = value; }
        }

        /// <summary>
        /// Text color (foreground) for the page number. Default is Black
        /// </summary>
        private Color pagenocolor;
        public Color PageNumberColor
        {
            get { return pagenocolor; }
            set { pagenocolor = value; }
        }

        /// <summary>
        /// Allow override of the header cell format object
        /// </summary>
        private StringFormat pagenumberformat;
        public StringFormat PageNumberFormat
        {
            get { return pagenumberformat; }
            set { pagenumberformat = value; overridepagenumberformat = true; }
        }

        /// <summary>
        /// Allow the user to override the page number string alignment. Default value is 
        /// Alignment - Near; 
        /// </summary>
        public StringAlignment PageNumberAlignment
        {
            get { return pagenumberformat.Alignment; }
            set
            {
                pagenumberformat.Alignment = value;
                overridepagenumberformat = true;
            }
        }

        /// <summary>
        /// Allow the user to override the pagenumber string format flags. Default values
        /// are: FormatFlags - NoWrap, LineLimit, NoClip
        /// </summary>
        public StringFormatFlags PageNumberFormatFlags
        {
            get { return pagenumberformat.FormatFlags; }
            set
            {
                pagenumberformat.FormatFlags = value;
                overridepagenumberformat = true;
            }
        }

        /// <summary>
        /// Allow the user to select whether to have the page number at the top or bottom
        /// of the page. Default is false: page numbers on the bottom of the page
        /// </summary>
        private bool pagenumberontop = false;
        public bool PageNumberInHeader
        {
            get { return pagenumberontop; }
            set { pagenumberontop = value; }
        }

        /// <summary>
        /// Should the page number be printed on a separate line, or printed on the
        /// same line as the header / footer? Default is false;
        /// </summary>
        private bool pagenumberonseparateline = false;
        public bool PageNumberOnSeparateLine
        {
            get { return pagenumberonseparateline; }
            set { pagenumberonseparateline = value; }
        }

        /// <summary>
        /// Show the total page number as n of total 
        /// </summary>
        private int totalpages;
        private bool showtotalpagenumber = false;
        public bool ShowTotalPageNumber
        {
            get { return showtotalpagenumber; }
            set { showtotalpagenumber = value; }
        }

        /// <summary>
        /// Text separating page number and total page number. Default is ' of '.
        /// </summary>
        private String pageseparator = " of ";
        public String PageSeparator
        {
            get { return pageseparator; }
            set { pageseparator = value; }
        }

        private String pagetext = "Page ";
        public String PageText
        {
            get { return pagetext; }
            set { pagetext = value; }
        }

        private String parttext = " - Part ";
        public String PartText
        {
            get { return parttext; }
            set { parttext = value; }
        }

        #endregion

        // Header Cell Printing 
        #region header cell properties

        private DataGridViewCellStyle rowheaderstyle;
        public DataGridViewCellStyle RowHeaderCellStyle
        {
            get { return rowheaderstyle; }
            set { rowheaderstyle = value; }
        }

        /// <summary>
        /// Allow override of the row header cell format object
        /// </summary>
        private StringFormat rowheadercellformat = null;
        public StringFormat GetRowHeaderCellFormat(DataGridView grid)
        {
            // get default values from provided data grid view, but only
            // if we don't already have a header cell format
            if ((null != grid) && (null == rowheadercellformat))
            {
                buildstringformat(ref rowheadercellformat, grid.Rows[0].HeaderCell.InheritedStyle,
                    headercellalignment, StringAlignment.Near, headercellformatflags,
                    StringTrimming.Word);
            }

            // if we still don't have a header cell format, create an empty
            if (null == rowheadercellformat)
                rowheadercellformat = new StringFormat(headercellformatflags);

            return rowheadercellformat;
        }

        /// <summary>
        /// Default value to show in the row header cell if no value is provided in the DataGridView.
        /// Defaults to one tab space
        /// </summary>
        private String rowheadercelldefaulttext = "\t";
        public String RowHeaderCellDefaultText
        {
            get { return rowheadercelldefaulttext; }
            set { rowheadercelldefaulttext = value; }
        }

        /// <summary>
        /// Allow override of the header cell format object
        /// </summary>
        private Dictionary<string, DataGridViewCellStyle> columnheaderstyles =
            new Dictionary<string, DataGridViewCellStyle>();
        public Dictionary<string, DataGridViewCellStyle> ColumnHeaderStyles
        {
            get { return columnheaderstyles; }
        }

        /// <summary>
        /// Allow override of the header cell format object
        /// </summary>
        private StringFormat columnheadercellformat = null;
        public StringFormat GetColumnHeaderCellFormat(DataGridView grid)
        {
            // get default values from provided data grid view, but only
            // if we don't already have a header cell format
            if ((null != grid) && (null == columnheadercellformat))
            {
                buildstringformat(ref columnheadercellformat, grid.Columns[0].HeaderCell.InheritedStyle,
                    headercellalignment, StringAlignment.Near, headercellformatflags,
                    StringTrimming.Word);
            }

            // if we still don't have a header cell format, create an empty
            if (null == columnheadercellformat)
                columnheadercellformat = new StringFormat(headercellformatflags);

            return columnheadercellformat;
        }

        /// <summary>
        /// Deprecated - use HeaderCellFormat
        /// Allow the user to override the header cell string alignment. Default value is 
        /// Alignment - Near; 
        /// </summary>
        private StringAlignment headercellalignment;
        public StringAlignment HeaderCellAlignment
        {
            get { return headercellalignment; }
            set { headercellalignment = value; }
        }

        /// <summary>
        /// Deprecated - use HeaderCellFormat
        /// Allow the user to override the header cell string format flags. Default values
        /// are: FormatFlags - NoWrap, LineLimit, NoClip
        /// </summary>
        private StringFormatFlags headercellformatflags;
        public StringFormatFlags HeaderCellFormatFlags
        {
            get { return headercellformatflags; }
            set { headercellformatflags = value; }
        }
        #endregion

        // Individual Cell Printing
        #region cell properties

        /// <summary>
        /// Allow override of the cell printing format
        /// </summary>
        private StringFormat cellformat = null;
        public StringFormat GetCellFormat(DataGridView grid)
        {
            // get default values from provided data grid view, but only
            // if we don't already have a cell format
            if ((null != grid) && (null == cellformat))
            {
                buildstringformat(ref cellformat, grid.Rows[0].Cells[0].InheritedStyle,
                    cellalignment, StringAlignment.Near, cellformatflags,
                    StringTrimming.Word);
            }

            // if we still don't have a cell format, create an empty
            if (null == cellformat)
                cellformat = new StringFormat(cellformatflags);

            return cellformat;
        }

        /// <summary>
        /// Deprecated - use GetCellFormat
        /// Allow the user to override the cell string alignment. Default value is 
        /// Alignment - Near; 
        /// </summary>
        private StringAlignment cellalignment;
        public StringAlignment CellAlignment
        {
            get { return cellalignment; }
            set { cellalignment = value; }
        }

        /// <summary>
        /// Deprecated - use GetCellFormat
        /// Allow the user to override the cell string format flags. Default values
        /// are: FormatFlags - NoWrap, LineLimit, NoClip
        /// </summary>
        private StringFormatFlags cellformatflags;
        public StringFormatFlags CellFormatFlags
        {
            get { return cellformatflags; }
            set { cellformatflags = value; }
        }

        /// <summary>
        /// allow the user to override the column width calcs with their own defaults
        /// </summary>
        private List<float> colwidthsoverride = new List<float>();
        private Dictionary<string, float> publicwidthoverrides = new Dictionary<string, float>();
        public Dictionary<string, float> ColumnWidths
        {
            get { return publicwidthoverrides; }
        }

        /// <summary>
        /// Allow per column style overrides
        /// </summary>
        private Dictionary<string, DataGridViewCellStyle> colstyles =
            new Dictionary<string, DataGridViewCellStyle>();
        public Dictionary<string, DataGridViewCellStyle> ColumnStyles
        {
            get { return colstyles; }
        }

        #endregion

        // Page Level Properties
        #region page level properties

        /// <summary>
        /// Page margins override. Default is (60, 60, 40, 40)
        /// </summary>
        public Margins PrintMargins
        {
            get { return PageSettings.Margins; }
            set { PageSettings.Margins = value; }
        }

        /// <summary>
        /// Expose the printdocument default page settings to the caller
        /// </summary>
        public PageSettings PageSettings
        {
            get { return printDoc.DefaultPageSettings; }
        }

        /// <summary>
        /// Spread the columns porportionally accross the page. Default is false.
        /// </summary>
        private bool porportionalcolumns = false;
        public bool PorportionalColumns
        {
            get { return porportionalcolumns; }
            set { porportionalcolumns = value; }
        }

        /// <summary>
        /// Center the table on the page. 
        /// </summary>
        private Alignment tablealignment = Alignment.NotSet;
        public Alignment TableAlignment
        {
            get { return tablealignment; }
            set { tablealignment = value; }
        }

        /// <summary>
        /// Change the default row height to either the height of the string or the size of 
        /// the cell. Added for image cell handling.
        /// </summary>
        public enum RowHeightSetting { StringHeight, CellHeight }
        private RowHeightSetting _rowheight = RowHeightSetting.StringHeight;
        public RowHeightSetting RowHeight
        {
            get { return _rowheight; }
            set { _rowheight = value; }
        }




        #endregion

        // Utility Functions
        #region
        /// <summary>
        /// calculate the print preview window width to show the entire page
        /// </summary>
        /// <returns></returns>
        private int PreviewDisplayWidth()
        {
            double displayWidth = printDoc.DefaultPageSettings.Bounds.Width
                + 3 * printDoc.DefaultPageSettings.HardMarginY;
            return (int)(displayWidth * PrintPreviewZoom);
        }

        /// <summary>
        /// calculate the print preview window height to show the entire page
        /// </summary>
        /// <returns></returns>
        private int PreviewDisplayHeight()
        {
            double displayHeight = printDoc.DefaultPageSettings.Bounds.Height
                + 3 * printDoc.DefaultPageSettings.HardMarginX;

            return (int)(displayHeight * PrintPreviewZoom);
        }

        /// <summary>
        /// Invoke any provided cell owner draw routines
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCellOwnerDraw(DGVCellDrawingEventArgs e)
        {
            if (null != OwnerDraw)
                OwnerDraw(this, e);
        }

        #endregion

        #endregion


        public DGVPrinter()
        {
            // create print document
            printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDoc.BeginPrint += new PrintEventHandler(printDoc_BeginPrint);
            PrintMargins = new Margins(60, 60, 40, 40);

            // set default fonts
            pagenofont = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            pagenocolor = Color.Black;
            titlefont = new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point);
            titlecolor = Color.Black;
            subtitlefont = new Font("Tahoma", 12, FontStyle.Bold, GraphicsUnit.Point);
            subtitlecolor = Color.Black;
            footerfont = new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point);
            footercolor = Color.Black;

            // default spacing
            titlespacing = 0;
            subtitlespacing = 0;
            footerspacing = 0;

            // Create string formatting objects
            buildstringformat(ref titleformat, null, StringAlignment.Center, StringAlignment.Center,
                StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip, StringTrimming.Word);
            buildstringformat(ref subtitleformat, null, StringAlignment.Center, StringAlignment.Center,
                StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip, StringTrimming.Word);
            buildstringformat(ref footerformat, null, StringAlignment.Center, StringAlignment.Center,
                StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip, StringTrimming.Word);
            buildstringformat(ref pagenumberformat, null, StringAlignment.Far, StringAlignment.Center,
                StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip, StringTrimming.Word);


            columnheadercellformat = null;
            rowheadercellformat = null;
            cellformat = null;

            // Print Preview properties
            Owner = null;
            PrintPreviewZoom = 1.0;


            headercellalignment = StringAlignment.Near;
            headercellformatflags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            cellalignment = StringAlignment.Near;
            cellformatflags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
        }





        public void PrintDataGridView(DataGridView dgv)
        {
            if (null == dgv) throw new Exception("Null Parameter passed to DGVPrinter.");
            if (typeof(DataGridView) != dgv.GetType())
                throw new Exception("Invalid Parameter passed to DGVPrinter.");

            // save the datagridview we're printing
            this.dgv = dgv;

            // display dialog and print
            if (DialogResult.OK == DisplayPrintDialog())
            {
                SetupPrint();
                printDoc.Print();
            }
        }

        public void PrintPreviewDataGridView(DataGridView dgv)
        {
            if (null == dgv) throw new Exception("Null Parameter passed to DGVPrinter.");
            if (typeof(DataGridView) != dgv.GetType())
                throw new Exception("Invalid Parameter passed to DGVPrinter.");

            // save the datagridview we're printing
            this.dgv = dgv;

            // display dialog and print
            if (DialogResult.OK == DisplayPrintDialog())
            {
                PrintPreviewNoDisplay(dgv);

                //SetupPrint();
                //PrintPreviewDialog ppdialog = new PrintPreviewDialog();
                //ppdialog.Document = printDoc;
                //ppdialog.UseAntiAlias = true;
                //ppdialog.Owner = Owner;
                //ppdialog.PrintPreviewControl.Zoom = PrintPreviewZoom;
                //ppdialog.Width = PreviewDisplayWidth();
                //ppdialog.Height = PreviewDisplayHeight();

                //if (null != ppvIcon) 
                //    ppdialog.Icon = ppvIcon;
                //ppdialog.ShowDialog();
            }
        }




        public DialogResult DisplayPrintDialog()
        {
            // create new print dialog and set options
            PrintDialog pd = new PrintDialog();
            pd.UseEXDialog = printDialogSettings.UseEXDialog;
            pd.AllowSelection = printDialogSettings.AllowSelection;
            pd.AllowSomePages = printDialogSettings.AllowSomePages;
            pd.AllowCurrentPage = printDialogSettings.AllowCurrentPage;
            pd.AllowPrintToFile = printDialogSettings.AllowPrintToFile;
            pd.ShowHelp = printDialogSettings.ShowHelp;
            pd.ShowNetwork = printDialogSettings.ShowNetwork;

            // setup print dialog with internal setttings
            pd.Document = printDoc;
            if (!String.IsNullOrEmpty(printerName))
                printDoc.PrinterSettings.PrinterName = printerName;

            printDoc.PrinterSettings = pd.PrinterSettings;
            printDoc.DefaultPageSettings.Landscape = pd.PrinterSettings.DefaultPageSettings.Landscape;
            printDoc.DefaultPageSettings.PaperSize =
                new PaperSize(pd.PrinterSettings.DefaultPageSettings.PaperSize.PaperName,
                    pd.PrinterSettings.DefaultPageSettings.PaperSize.Width,
                    pd.PrinterSettings.DefaultPageSettings.PaperSize.Height);


            return pd.ShowDialog();
        }


        public void PrintNoDisplay(DataGridView dgv)
        {
            if (null == dgv) throw new Exception("Null Parameter passed to DGVPrinter.");
            if (typeof(DataGridView) != dgv.GetType())
                throw new Exception("Invalid Parameter passed to DGVPrinter.");


            this.dgv = dgv;


            SetupPrint();
            printDoc.Print();
        }


        public void PrintPreviewNoDisplay(DataGridView dgv)
        {
            if (null == dgv) throw new Exception("Null Parameter passed to DGVPrinter.");
            if (typeof(DataGridView) != dgv.GetType())
                throw new Exception("Invalid Parameter passed to DGVPrinter.");


            this.dgv = dgv;


            SetupPrint();
            PrintPreviewDialog ppdialog = new PrintPreviewDialog();
            ppdialog.Document = printDoc;
            ppdialog.UseAntiAlias = true;
            ppdialog.Owner = Owner;
            ppdialog.PrintPreviewControl.Zoom = PrintPreviewZoom;
            ppdialog.Width = PreviewDisplayWidth();
            ppdialog.Height = PreviewDisplayHeight();

            if (null != ppvIcon)
                ppdialog.Icon = ppvIcon;
            ppdialog.ShowDialog();
        }



        public bool EmbeddedPrint(DataGridView dgv, Graphics g, Rectangle area)
        {

            if ((null == dgv) || (null == g))
                throw new Exception("Null Parameter passed to DGVPrinter.");


            this.dgv = dgv;


            Margins saveMargins = PrintMargins;
            PrintMargins.Top = area.Top;
            PrintMargins.Bottom = 0;
            PrintMargins.Left = area.Left;
            PrintMargins.Right = 0;


            pageHeight = area.Height + area.Top;
            printWidth = area.Width;
            pageWidth = area.Width + area.Left;


            fromPage = 0;
            toPage = maxPages;


            PrintHeader = false;
            PrintFooter = false;

            // set cell format
            if (null == cellformat)
                buildstringformat(ref cellformat, dgv.DefaultCellStyle,
                    cellalignment, StringAlignment.Near, cellformatflags,
                    StringTrimming.Word);

            rowstoprint = new List<object>(dgv.Rows.Count);
            foreach (DataGridViewRow row in dgv.Rows) if (row.Visible) rowstoprint.Add(row);

            colstoprint = new List<object>(dgv.Columns.Count);
            foreach (DataGridViewColumn col in dgv.Columns) if (col.Visible) colstoprint.Add(col);


            SortedList displayorderlist = new SortedList(colstoprint.Count);
            foreach (DataGridViewColumn col in colstoprint) displayorderlist.Add(col.DisplayIndex, col);
            colstoprint.Clear();
            foreach (object item in displayorderlist.Values) colstoprint.Add(item);


            foreach (DataGridViewColumn col in colstoprint)
                if (publicwidthoverrides.ContainsKey(col.Name))
                    colwidthsoverride.Add(publicwidthoverrides[col.Name]);
                else
                    colwidthsoverride.Add(-1);

            measureprintarea(g);


            totalpages = TotalPages();


            currentpageset = 0;
            lastrowprinted = -1;
            CurrentPage = 0;


            return PrintPage(g);


        }


        void printDoc_BeginPrint(object sender, PrintEventArgs e)
        {

            currentpageset = 0;
            lastrowprinted = -1;
            CurrentPage = 0;
        }


        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = PrintPage(e.Graphics);
        }



        void SetupPrint()
        {
            if (null == PrintColumnHeaders)
                PrintColumnHeaders = dgv.Columns[0].HeaderCell.Visible;

            if (null == PrintRowHeaders)
                PrintRowHeaders = dgv.RowHeadersVisible;


            if (null == RowHeaderCellStyle)
                RowHeaderCellStyle = dgv.Rows[0].HeaderCell.InheritedStyle;

            /* Functionality to come - redo of styling
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                // Set the default column styles where we've not been given an override
                if (!ColumnStyles.ContainsKey(col.Name))
                    ColumnStyles[col.Name] = dgv.Columns[col.Name].InheritedStyle;

                // Set the default column header styles where we don't have an override
                if (!ColumnHeaderStyles.ContainsKey(col.Name))
                    ColumnHeaderStyles[col.Name] = dgv.Columns[col.Name].HeaderCell.InheritedStyle;
            }
            */


            if (null == columnheadercellformat)
                buildstringformat(ref columnheadercellformat, dgv.Columns[0].HeaderCell.InheritedStyle,
                    headercellalignment, StringAlignment.Near, headercellformatflags,
                    StringTrimming.Word);
            if (null == rowheadercellformat)
                buildstringformat(ref rowheadercellformat, RowHeaderCellStyle,
                    headercellalignment, StringAlignment.Near, headercellformatflags,
                    StringTrimming.Word);
            if (null == cellformat)
                buildstringformat(ref cellformat, dgv.DefaultCellStyle,
                    cellalignment, StringAlignment.Near, cellformatflags,
                    StringTrimming.Word);


            int hardx = (int)Math.Round(printDoc.DefaultPageSettings.HardMarginX);
            int hardy = (int)Math.Round(printDoc.DefaultPageSettings.HardMarginY);
            int printareawidth;
            if (printDoc.DefaultPageSettings.Landscape)
                printareawidth = (int)Math.Round(printDoc.DefaultPageSettings.PrintableArea.Height);
            else
                printareawidth = (int)Math.Round(printDoc.DefaultPageSettings.PrintableArea.Width);



            pageHeight = printDoc.DefaultPageSettings.Bounds.Height;
            pageWidth = printDoc.DefaultPageSettings.Bounds.Width;


            PrintMargins = printDoc.DefaultPageSettings.Margins;


            PrintMargins.Right = (hardx > PrintMargins.Right) ? hardx : PrintMargins.Right;
            PrintMargins.Left = (hardx > PrintMargins.Left) ? hardx : PrintMargins.Left;
            PrintMargins.Top = (hardy > PrintMargins.Top) ? hardy : PrintMargins.Top;
            PrintMargins.Bottom = (hardy > PrintMargins.Bottom) ? hardy : PrintMargins.Bottom;


            printWidth = pageWidth - PrintMargins.Left - PrintMargins.Right;
            printWidth = (printWidth > printareawidth) ? printareawidth : printWidth;


            printRange = printDoc.PrinterSettings.PrintRange;


            if (PrintRange.SomePages == printRange)
            {

                fromPage = printDoc.PrinterSettings.FromPage;
                toPage = printDoc.PrinterSettings.ToPage;
            }
            else
            {

                fromPage = 0;
                toPage = maxPages;
            }


            if (PrintRange.Selection == printRange)
            {
                SortedList temprowstoprint;
                SortedList tempcolstoprint;

                if (0 != dgv.SelectedRows.Count)
                {
                    // sort the rows into index order
                    temprowstoprint = new SortedList(dgv.SelectedRows.Count);
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                        temprowstoprint.Add(row.Index, row);

                    IEnumerator ie = temprowstoprint.Values.GetEnumerator();

                    rowstoprint = new List<object>(temprowstoprint.Count);
                    foreach (object item in temprowstoprint.Values) rowstoprint.Add(item);

                    colstoprint = new List<object>(dgv.Columns.Count);
                    foreach (DataGridViewColumn col in dgv.Columns) if (col.Visible) colstoprint.Add(col);
                }

                else if (0 != dgv.SelectedColumns.Count)
                {
                    rowstoprint = dgv.Rows;

                    tempcolstoprint = new SortedList(dgv.SelectedColumns.Count);
                    foreach (DataGridViewRow row in dgv.SelectedColumns)
                        tempcolstoprint.Add(row.Index, row);

                    colstoprint = new List<object>(tempcolstoprint.Count);
                    foreach (object item in tempcolstoprint.Values) colstoprint.Add(item);
                }

                else
                {

                    temprowstoprint = new SortedList(dgv.SelectedCells.Count);
                    tempcolstoprint = new SortedList(dgv.SelectedCells.Count);


                    int colindex, rowindex;
                    foreach (DataGridViewCell cell in dgv.SelectedCells)
                    {
                        colindex = cell.ColumnIndex;
                        rowindex = cell.RowIndex;


                        if (!temprowstoprint.Contains(rowindex))
                            temprowstoprint.Add(rowindex, dgv.Rows[rowindex]);


                        if (!tempcolstoprint.Contains(colindex))
                            tempcolstoprint.Add(colindex, dgv.Columns[colindex]);
                    }


                    rowstoprint = new List<object>(temprowstoprint.Count);
                    foreach (object item in temprowstoprint.Values) rowstoprint.Add(item);
                    colstoprint = new List<object>(tempcolstoprint.Count);
                    foreach (object item in tempcolstoprint.Values) colstoprint.Add(item);
                }
            }

            else if (PrintRange.CurrentPage == printRange)
            {

                rowstoprint = new List<object>(dgv.DisplayedRowCount(true));
                colstoprint = new List<object>(dgv.Columns.Count);


                for (int i = dgv.FirstDisplayedScrollingRowIndex;
                    i < dgv.FirstDisplayedScrollingRowIndex + dgv.DisplayedRowCount(true);
                    i++)
                {
                    DataGridViewRow row = dgv.Rows[i];
                    if (row.Visible) rowstoprint.Add(row);
                }


                colstoprint = new List<object>(dgv.Columns.Count);
                foreach (DataGridViewColumn col in dgv.Columns) if (col.Visible) colstoprint.Add(col);
            }

            else
            {

                rowstoprint = new List<object>(dgv.Rows.Count);
                foreach (DataGridViewRow row in dgv.Rows) if (row.Visible && !row.IsNewRow) rowstoprint.Add(row);

                colstoprint = new List<object>(dgv.Columns.Count);
                foreach (DataGridViewColumn col in dgv.Columns) if (col.Visible) colstoprint.Add(col);
            }


            int rev = 1;
            if (RightToLeft.Yes == dgv.RightToLeft) rev = -1;
            SortedList displayorderlist = new SortedList(colstoprint.Count);
            foreach (DataGridViewColumn col in colstoprint) displayorderlist.Add(rev * col.DisplayIndex, col);
            colstoprint.Clear();
            foreach (object item in displayorderlist.Values) colstoprint.Add(item);


            foreach (DataGridViewColumn col in colstoprint)
                if (publicwidthoverrides.ContainsKey(col.Name))
                    colwidthsoverride.Add(publicwidthoverrides[col.Name]);
                else
                    colwidthsoverride.Add(-1);


            measureprintarea(printDoc.PrinterSettings.CreateMeasurementGraphics());


            totalpages = TotalPages();

        }


        private void buildstringformat(ref StringFormat format, DataGridViewCellStyle controlstyle,
            StringAlignment alignment, StringAlignment linealignment, StringFormatFlags flags,
            StringTrimming trim)
        {

            if (null == format)
                format = new StringFormat();

            // Set defaults
            format.Alignment = alignment;
            format.LineAlignment = linealignment;
            format.FormatFlags = flags;
            format.Trimming = trim;


            if ((null != dgv) && (RightToLeft.Yes == dgv.RightToLeft))
                format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;


            if (null != controlstyle)
            {

                DataGridViewContentAlignment cellalign = controlstyle.Alignment;
                if (cellalign.ToString().Contains("Center")) format.Alignment = StringAlignment.Center;
                else if (cellalign.ToString().Contains("Left")) format.Alignment = StringAlignment.Near;
                else if (cellalign.ToString().Contains("Right")) format.Alignment = StringAlignment.Far;

                if (cellalign.ToString().Contains("Top")) format.LineAlignment = StringAlignment.Near;
                else if (cellalign.ToString().Contains("Middle")) format.LineAlignment = StringAlignment.Center;
                else if (cellalign.ToString().Contains("Bottom")) format.LineAlignment = StringAlignment.Far;
            }
        }


        private void measureprintarea(Graphics g)
        {
            int i, j;
            rowheights = new List<float>(rowstoprint.Count);
            colwidths = new List<float>(colstoprint.Count);
            headerHeight = 0;
            footerHeight = 0;

            // temp variables
            DataGridViewColumn col;
            DataGridViewRow row;


            Font headerfont = dgv.ColumnHeadersDefaultCellStyle.Font;
            if (null == headerfont)
                headerfont = dgv.DefaultCellStyle.Font;

            for (i = 0; i < colstoprint.Count; i++)
            {
                col = (DataGridViewColumn)colstoprint[i];

                StringFormat currentformat = null;
                DataGridViewCellStyle headercolstyle = null;
                if (ColumnHeaderStyles.ContainsKey(col.Name))
                {
                    headercolstyle = columnheaderstyles[col.Name];


                    buildstringformat(ref currentformat, headercolstyle, cellformat.Alignment, cellformat.LineAlignment,
                        cellformat.FormatFlags, cellformat.Trimming);
                }
                else if (col.HasDefaultCellStyle)
                {
                    headercolstyle = col.HeaderCell.InheritedStyle;


                    buildstringformat(ref currentformat, headercolstyle, cellformat.Alignment, cellformat.LineAlignment,
                        cellformat.FormatFlags, cellformat.Trimming);
                }
                else
                {
                    currentformat = columnheadercellformat;
                    headercolstyle = dgv.DefaultCellStyle;
                }


                float usewidth = 0;
                if (0 <= colwidthsoverride[i])
                    usewidth = colwidthsoverride[i];
                else
                    usewidth = printWidth;

                SizeF size = g.MeasureString(col.HeaderText, headercolstyle.Font, new SizeF(usewidth, maxPages),
                    columnheadercellformat);
                colwidths.Add(size.Width);
                colheaderheight = (colheaderheight < size.Height ? size.Height : colheaderheight);
            }


            if (pageno)
            {
                pagenumberHeight = (g.MeasureString("Page", pagenofont, printWidth, pagenumberformat)).Height;
            }


            if (PrintHeader)
            {


                if (pagenumberontop && !pagenumberonseparateline)
                {
                    headerHeight += pagenumberHeight;
                }

                if (!String.IsNullOrEmpty(title))
                {
                    headerHeight += (g.MeasureString(title, titlefont, printWidth, titleformat)).Height;
                }

                if (!String.IsNullOrEmpty(subtitle))
                {
                    headerHeight += (g.MeasureString(subtitle, subtitlefont, printWidth, subtitleformat)).Height;
                }

                if ((bool)PrintColumnHeaders)
                {
                    headerHeight += colheaderheight;
                }

                headerHeight += titlespacing + subtitlespacing;
            }


            if (PrintFooter)
            {
                if (!String.IsNullOrEmpty(footer))
                {
                    footerHeight += (g.MeasureString(footer, footerfont, printWidth, footerformat)).Height;
                }


                if (!pagenumberontop && pagenumberonseparateline)
                {
                    footerHeight += pagenumberHeight;
                }

                footerHeight += footerspacing;
            }


            for (i = 0; i < rowstoprint.Count; i++)
            {
                row = (DataGridViewRow)rowstoprint[i];
                rowheights.Add(0);


                if ((bool)PrintRowHeaders)
                {

                    String rowheadertext = String.IsNullOrEmpty(row.HeaderCell.EditedFormattedValue.ToString())
                        ? rowheadercelldefaulttext : row.HeaderCell.EditedFormattedValue.ToString();

                    SizeF rhsize = g.MeasureString(rowheadertext,
                        headerfont);
                    rowheaderwidth = (rowheaderwidth < rhsize.Width) ? rhsize.Width : rowheaderwidth;
                }


                for (j = 0; j < colstoprint.Count; j++)
                {
                    col = (DataGridViewColumn)colstoprint[j];


                    String datastr = row.Cells[col.Index].EditedFormattedValue.ToString();


                    StringFormat currentformat = null;
                    DataGridViewCellStyle colstyle = null;
                    if (ColumnStyles.ContainsKey(col.Name))
                    {
                        colstyle = colstyles[col.Name];


                        buildstringformat(ref currentformat, colstyle, cellformat.Alignment, cellformat.LineAlignment,
                            cellformat.FormatFlags, cellformat.Trimming);
                    }
                    else if ((col.HasDefaultCellStyle) || (row.Cells[col.Index].HasStyle))
                    {
                        colstyle = row.Cells[col.Index].InheritedStyle;

                        buildstringformat(ref currentformat, colstyle, cellformat.Alignment, cellformat.LineAlignment,
                            cellformat.FormatFlags, cellformat.Trimming);
                    }
                    else
                    {
                        currentformat = cellformat;
                        colstyle = dgv.DefaultCellStyle;
                    }


                    SizeF size;
                    if (RowHeightSetting.CellHeight == RowHeight)
                        size = row.Cells[col.Index].Size;
                    else
                        size = g.MeasureString(datastr, colstyle.Font);

                    if ((0 <= colwidthsoverride[j]) || (size.Width > printWidth))
                    {
                        // set column width
                        if (0 <= colwidthsoverride[j])
                            colwidths[j] = colwidthsoverride[j];
                        else if (size.Width > printWidth)
                            colwidths[j] = printWidth;


                        int chars, lines;
                        size = g.MeasureString(datastr, colstyle.Font, new SizeF(colwidths[j] - colstyle.Padding.Left - colstyle.Padding.Right, maxPages),
                            currentformat, out chars, out lines);


                        float tempheight = size.Height + colstyle.Padding.Top + colstyle.Padding.Bottom;
                        rowheights[i] = (rowheights[i] < tempheight ? tempheight : rowheights[i]);
                    }
                    else
                    {

                        float tempwidth = size.Width + colstyle.Padding.Left + colstyle.Padding.Right;
                        float tempheight = size.Height + colstyle.Padding.Top + colstyle.Padding.Bottom;

                        colwidths[j] = (colwidths[j] < tempwidth ? tempwidth : colwidths[j]);
                        rowheights[i] = (rowheights[i] < tempheight ? tempheight : rowheights[i]);
                    }
                }
            }


            pagesets = new List<PageDef>();
            pagesets.Add(new PageDef(PrintMargins, colstoprint.Count));
            int pset = 0;


            pagesets[pset].coltotalwidth = rowheaderwidth;


            float columnwidth;
            for (i = 0; i < colstoprint.Count; i++)
            {

                columnwidth = (colwidthsoverride[i] >= 0)
                    ? colwidthsoverride[i] : colwidths[i];


                if (printWidth < (pagesets[pset].coltotalwidth + columnwidth) && i != 0)
                {
                    pagesets.Add(new PageDef(PrintMargins, colstoprint.Count));
                    pset++;


                    pagesets[pset].coltotalwidth = rowheaderwidth;
                }


                pagesets[pset].colstoprint.Add(colstoprint[i]);
                pagesets[pset].colwidths.Add(colwidths[i]);
                pagesets[pset].colwidthsoverride.Add(colwidthsoverride[i]);
                pagesets[pset].coltotalwidth += columnwidth;
            }


            for (i = 0; i < pagesets.Count; i++)
                AdjustPageSets(g, pagesets[i]);
        }


        private void AdjustPageSets(Graphics g, PageDef pageset)
        {
            int i;
            float fixedcolwidth = rowheaderwidth;
            float remainingcolwidth = 0;
            float ratio;


            for (i = 0; i < pageset.colwidthsoverride.Count; i++)
                if (pageset.colwidthsoverride[i] >= 0)
                    fixedcolwidth += pageset.colwidthsoverride[i];


            for (i = 0; i < pageset.colwidths.Count; i++)
                if (pageset.colwidthsoverride[i] < 0)
                    remainingcolwidth += pageset.colwidths[i];


            if (porportionalcolumns && 0 < remainingcolwidth)
                ratio = ((float)printWidth - fixedcolwidth) / (float)remainingcolwidth;
            else
                ratio = (float)1.0;


            pageset.coltotalwidth = rowheaderwidth;
            for (i = 0; i < pageset.colwidths.Count; i++)
            {
                if (pageset.colwidthsoverride[i] >= 0)
                    pageset.colwidths[i] = pageset.colwidthsoverride[i];
                else
                    pageset.colwidths[i] = pageset.colwidths[i] * ratio;

                pageset.coltotalwidth += pageset.colwidths[i];
            }


            if (Alignment.Left == tablealignment)
            {

                pageset.margins.Right = pageWidth - pageset.margins.Left - (int)pageset.coltotalwidth;
                if (0 > pageset.margins.Right) pageset.margins.Right = 0;
            }
            else if (Alignment.Right == tablealignment)
            {

                pageset.margins.Left = pageWidth - pageset.margins.Right - (int)pageset.coltotalwidth;
                if (0 > pageset.margins.Left) pageset.margins.Left = 0;
            }
            else if (Alignment.Center == tablealignment)
            {

                pageset.margins.Left = (pageWidth - (int)pageset.coltotalwidth) / 2;
                if (0 > pageset.margins.Left) pageset.margins.Left = 0;
                pageset.margins.Right = pageset.margins.Left;
            }
        }


        private int TotalPages()
        {
            int pages = 1;
            float pos = 0;


            float printablearea = pageHeight - headerHeight - footerHeight -
                PrintMargins.Top - PrintMargins.Bottom;


            if (toPage < maxPages)
                return toPage;


            for (int i = 0; i < (rowheights.Count); i++)
            {
                if (pos + rowheights[i] > printablearea)
                {
                    // count the page
                    pages++;
                    // reset the counter
                    pos = 0;
                }

                // add space
                pos += rowheights[i];
            }

            return pages;
        }


        private bool DetermineHasMorePages()
        {
            currentpageset++;
            if (currentpageset < pagesets.Count)
            {

                return true;
            }
            else
                return false;
        }


        private bool PrintPage(Graphics g)
        {

            bool HasMorePages = false;


            bool printthispage = false;


            float printpos = pagesets[currentpageset].margins.Top;


            CurrentPage++;
            if ((CurrentPage >= fromPage) && (CurrentPage <= toPage))
                printthispage = true;


            staticheight = pageHeight - footerHeight - pagesets[currentpageset].margins.Bottom;


            float nextrowheight;


            while (!printthispage)
            {

                printpos = pagesets[currentpageset].margins.Top + headerHeight;


                bool pagecomplete = false;
                currentrow = lastrowprinted + 1;


                nextrowheight = (lastrowprinted < rowheights.Count) ? rowheights[currentrow] : 0;
                do
                {

                    float used = (rowheights[currentrow] - rowstartlocation) > (staticheight - printpos)
                        ? (staticheight - printpos) : rowheights[currentrow] - rowstartlocation;
                    printpos += used;


                    if ((rowstartlocation + used) >= nextrowheight)
                    {

                        rowstartlocation = 0;
                        lastrowprinted++;
                        currentrow++;
                    }
                    else
                    {

                        rowstartlocation += used;
                        pagecomplete = true;
                    }


                    nextrowheight = (currentrow < rowheights.Count) ? rowheights[currentrow] : 0;

                    if ((0 == rowstartlocation) && keepRowsTogether)
                    {

                        if ((printpos + nextrowheight) >= staticheight)
                        {
                            pagecomplete = true;
                        }
                    }


                    if ((0 == rowstartlocation) && printpos >= staticheight)
                        pagecomplete = true;


                    if ((0 == rowstartlocation) && lastrowprinted >= rowstoprint.Count - 1)
                        pagecomplete = true;

                } while (!pagecomplete);


                CurrentPage++;

                if ((CurrentPage >= fromPage) && (CurrentPage <= toPage))
                    printthispage = true;


                if (0 != rowstartlocation)
                {

                    HasMorePages = true;
                }

                else if ((lastrowprinted >= rowstoprint.Count - 1) || (CurrentPage > toPage))
                {

                    HasMorePages = DetermineHasMorePages();


                    lastrowprinted = -1;
                    CurrentPage = 0;

                    return HasMorePages;
                }
            }


            printpos = pagesets[currentpageset].margins.Top;

            if (PrintHeader)
            {

                ImbeddedImageList.Where(p => p.ImageLocation == Location.Header).DrawImbeddedImage(g, printWidth,
                    pageHeight, pagesets[currentpageset].margins);


                if (pagenumberontop)
                {

                    if (pageno)
                    {
                        String pagenumber = pagetext + CurrentPage.ToString(CultureInfo.CurrentCulture);
                        if (showtotalpagenumber)
                        {
                            pagenumber += pageseparator + totalpages.ToString();
                        }
                        if (1 < pagesets.Count)
                            pagenumber += parttext + (currentpageset + 1).ToString(CultureInfo.CurrentCulture);

                        // ... then print it
                        printsection(g, ref printpos,
                            pagenumber, pagenofont, pagenocolor, pagenumberformat,
                            overridepagenumberformat, pagesets[currentpageset].margins);


                        if (!pagenumberonseparateline)
                            printpos -= pagenumberHeight;
                    }
                }


                if (!String.IsNullOrEmpty(title))
                    printsection(g, ref printpos, title, titlefont,
                        titlecolor, titleformat, overridetitleformat,
                        pagesets[currentpageset].margins);


                printpos += titlespacing;


                if (!String.IsNullOrEmpty(subtitle))
                    printsection(g, ref printpos, subtitle, subtitlefont,
                        subtitlecolor, subtitleformat, overridesubtitleformat,
                        pagesets[currentpageset].margins);

                printpos += subtitlespacing;
            }


            if ((bool)PrintColumnHeaders)
            {

                printcolumnheaders(g, ref printpos, pagesets[currentpageset]);
            }


            ImbeddedImageList.Where(p => p.ImageLocation == Location.Absolute).DrawImbeddedImage(g, printWidth,
                pageHeight, pagesets[currentpageset].margins);


            bool continueprinting = true;
            currentrow = lastrowprinted + 1;

            if (currentrow >= rowstoprint.Count)
            {

                return false;
            }

            nextrowheight = (lastrowprinted < rowheights.Count) ? rowheights[currentrow] : 0;
            do
            {

                float used = printrow(g, printpos, (DataGridViewRow)(rowstoprint[currentrow]),
                    pagesets[currentpageset], rowstartlocation);
                printpos += used;


                if ((rowstartlocation + used) >= nextrowheight)
                {

                    rowstartlocation = 0;
                    lastrowprinted++;
                    currentrow++;
                }
                else
                {

                    rowstartlocation += used;
                    continueprinting = false;
                }


                nextrowheight = (currentrow < rowheights.Count) ? rowheights[currentrow] : 0;

                if ((0 == rowstartlocation) && keepRowsTogether)
                {

                    if ((printpos + nextrowheight) >= staticheight)
                    {
                        continueprinting = false;
                    }
                }


                if ((0 == rowstartlocation) && printpos >= staticheight)
                    continueprinting = false;


                if ((0 == rowstartlocation) && lastrowprinted >= rowstoprint.Count - 1)
                    continueprinting = false;

            } while (continueprinting);


            if (PrintFooter)
            {

                ImbeddedImageList.Where(p => p.ImageLocation == Location.Footer).DrawImbeddedImage(g, printWidth,
                    pageHeight, pagesets[currentpageset].margins);

                printfooter(g, ref printpos, pagesets[currentpageset].margins);
            }


            if (0 != rowstartlocation)
            {

                HasMorePages = true;
            }


            if ((CurrentPage >= toPage) || (lastrowprinted >= rowstoprint.Count - 1))
            {

                HasMorePages = DetermineHasMorePages();


                lastrowprinted = -1;
                CurrentPage = 0;
            }
            else
            {
                // we're not done yet
                HasMorePages = true;
            }

            return HasMorePages;
        }


        private void printsection(Graphics g, ref float pos, string text,
            Font font, Color color, StringFormat format, bool useroverride, Margins margins)
        {

            SizeF printsize = g.MeasureString(text, font, printWidth, format);


            RectangleF printarea = new RectangleF((float)margins.Left, pos, (float)printWidth,
               printsize.Height);


            g.DrawString(text, font, new SolidBrush(color), printarea, format);


            pos += printsize.Height;
        }


        private void printfooter(Graphics g, ref float pos, Margins margins)
        {

            pos = pageHeight - footerHeight - margins.Bottom;  // - margins.Top

            // add spacing
            pos += footerspacing;

            // print the footer
            printsection(g, ref pos, footer, footerfont, footercolor, footerformat,
                overridefooterformat, margins);

            // print the page number if it's on the bottom.
            if (!pagenumberontop)
            {
                if (pageno)
                {
                    String pagenumber = pagetext + CurrentPage.ToString(CultureInfo.CurrentCulture);
                    if (showtotalpagenumber)
                    {
                        pagenumber += pageseparator + totalpages.ToString();
                    }
                    if (1 < pagesets.Count)
                        pagenumber += parttext + (currentpageset + 1).ToString(CultureInfo.CurrentCulture);

                    // if the pageno is not on a separate line, push the print location up by its height.
                    if (!pagenumberonseparateline)
                        pos = pos - pagenumberHeight;

                    // print the page number
                    printsection(g, ref pos, pagenumber, pagenofont, pagenocolor, pagenumberformat,
                        overridepagenumberformat, margins);
                }
            }
        }


        private void printcolumnheaders(Graphics g, ref float pos, PageDef pageset)
        {

            float xcoord = pageset.margins.Left + rowheaderwidth;


            Pen lines = new Pen(dgv.GridColor, 1);

            DataGridViewColumn col;
            for (int i = 0; i < pageset.colstoprint.Count; i++)
            {
                col = (DataGridViewColumn)pageset.colstoprint[i];


                float cellwidth = (pageset.colwidths[i] > printWidth - rowheaderwidth ?
                    printWidth - rowheaderwidth : pageset.colwidths[i]);

                // get column style
                DataGridViewCellStyle style = col.HeaderCell.InheritedStyle;
                if (ColumnHeaderStyles.ContainsKey(col.Name))
                {
                    style = ColumnHeaderStyles[col.Name];
                }


                RectangleF cellprintarea = new RectangleF(xcoord, pos, cellwidth, colheaderheight);


                g.FillRectangle(new SolidBrush(style.BackColor), cellprintarea);

                // draw the text
                g.DrawString(col.HeaderText, style.Font, new SolidBrush(style.ForeColor), cellprintarea,
                    columnheadercellformat);


                if (dgv.ColumnHeadersBorderStyle != DataGridViewHeaderBorderStyle.None)
                    g.DrawRectangle(lines, xcoord, pos, cellwidth, colheaderheight);

                xcoord += pageset.colwidths[i];
            }


            pos += colheaderheight +
                (dgv.ColumnHeadersBorderStyle != DataGridViewHeaderBorderStyle.None ? lines.Width : 0);
        }


        private float printrow(Graphics g, float finalpos, DataGridViewRow row, PageDef pageset,
            float startlocation)
        {

            float xcoord = pageset.margins.Left;
            float pos = finalpos;


            Pen lines = new Pen(dgv.GridColor, 1);


            float rowwidth = (pageset.coltotalwidth > printWidth ? printWidth : pageset.coltotalwidth);


            float rowheight = (rowheights[currentrow] - startlocation) > (staticheight - pos)
                ? (staticheight - pos) : rowheights[currentrow] - startlocation;


            DataGridViewCellStyle rowstyle = row.InheritedStyle;


            RectangleF printarea = new RectangleF(xcoord, pos, rowwidth,
                rowheight);


            g.FillRectangle(new SolidBrush(rowstyle.BackColor), printarea);


            if ((bool)PrintRowHeaders)
            {

                RectangleF headercellprintarea = new RectangleF(xcoord, pos,
                    rowheaderwidth, rowheight);


                g.FillRectangle(new SolidBrush(RowHeaderCellStyle.BackColor), headercellprintarea);


                String rowheadertext = String.IsNullOrEmpty(row.HeaderCell.EditedFormattedValue.ToString())
                    ? rowheadercelldefaulttext : row.HeaderCell.EditedFormattedValue.ToString();


                g.DrawString(rowheadertext,
                    RowHeaderCellStyle.Font, new SolidBrush(RowHeaderCellStyle.ForeColor), headercellprintarea,
                    rowheadercellformat);


                if (dgv.RowHeadersBorderStyle != DataGridViewHeaderBorderStyle.None)
                    g.DrawRectangle(lines, xcoord, pos, rowheaderwidth, rowheight);


                xcoord += rowheaderwidth;
            }


            DataGridViewColumn col;
            for (int i = 0; i < pageset.colstoprint.Count; i++)
            {

                col = (DataGridViewColumn)pageset.colstoprint[i];
                DataGridViewCell cell = row.Cells[col.Index];


                String datastr = cell.EditedFormattedValue.ToString();


                float cellwidth = (pageset.colwidths[i] > printWidth - rowheaderwidth ?
                    printWidth - rowheaderwidth : pageset.colwidths[i]);

                if (cellwidth > 0)
                {

                    StringFormat finalformat = null;
                    Font cellfont = null;
                    DataGridViewCellStyle colstyle = null;
                    if (ColumnStyles.ContainsKey(col.Name))
                    {
                        colstyle = colstyles[col.Name];

                        // set string format
                        buildstringformat(ref finalformat, colstyle, cellformat.Alignment, cellformat.LineAlignment,
                            cellformat.FormatFlags, cellformat.Trimming);
                        cellfont = colstyle.Font;
                    }
                    else if ((col.HasDefaultCellStyle) || (row.Cells[col.Index].HasStyle))
                    {
                        colstyle = row.Cells[col.Index].InheritedStyle;

                        // set string format
                        buildstringformat(ref finalformat, colstyle, cellformat.Alignment, cellformat.LineAlignment,
                            cellformat.FormatFlags, cellformat.Trimming);
                        cellfont = colstyle.Font;
                    }
                    else
                    {
                        finalformat = cellformat;

                        colstyle = row.Cells[col.Index].InheritedStyle;
                    }


                    RectangleF cellprintarea = new RectangleF(xcoord, pos, cellwidth,
                        rowheight);

                    if (!DrawOwnerDrawCell(g, row.Cells[col.Index], cellprintarea, colstyle))
                    {
                        RectangleF clip = g.ClipBounds;

                        //g.FillRectangle(new SolidBrush(colstyle.BackColor), cellprintarea);
                        g.FillRectangle(new SolidBrush(cell.InheritedStyle.BackColor), cellprintarea);


                        cellprintarea = new RectangleF(xcoord + colstyle.Padding.Left,
                            pos + colstyle.Padding.Top,
                            cellwidth - colstyle.Padding.Right - colstyle.Padding.Left,
                            rowheight - colstyle.Padding.Bottom - colstyle.Padding.Top);

                        g.SetClip(cellprintarea);


                        RectangleF actualprint = new RectangleF(cellprintarea.X, cellprintarea.Y - startlocation,
                            cellwidth, rowheights[currentrow]);


                        if ("DataGridViewImageCell" == col.CellType.Name)
                        {
                            DrawImageCell(g, (DataGridViewImageCell)row.Cells[col.Index], actualprint);
                        }
                        else
                        {

                            g.DrawString(datastr, colstyle.Font, new SolidBrush(cell.InheritedStyle.ForeColor),
                                actualprint, finalformat);
                        }


                        g.SetClip(clip);


                        if (dgv.CellBorderStyle != DataGridViewCellBorderStyle.None)
                            g.DrawRectangle(lines, xcoord, pos, cellwidth, rowheight);
                    }
                }

                xcoord += pageset.colwidths[i];
            }


            return rowheight;
        }

        Boolean DrawOwnerDrawCell(Graphics g, DataGridViewCell cell, RectangleF rectf,
            DataGridViewCellStyle style)
        {
            DGVCellDrawingEventArgs args = new DGVCellDrawingEventArgs(g, rectf, style,
                cell.RowIndex, cell.ColumnIndex);
            OnCellOwnerDraw(args);
            return args.Handled;
        }

        void DrawImageCell(Graphics g, DataGridViewImageCell imagecell, RectangleF rectf)
        {

            Image img = (System.Drawing.Image)imagecell.Value;


            Rectangle src = new Rectangle();


            int dx = 0;
            int dy = 0;


            if ((DataGridViewImageCellLayout.Normal == imagecell.ImageLayout) ||
                (DataGridViewImageCellLayout.NotSet == imagecell.ImageLayout))
            {

                dx = img.Width - (int)rectf.Width;
                dy = img.Height - (int)rectf.Height;


                if (0 > dx) rectf.Width = src.Width = img.Width; else src.Width = (int)rectf.Width;
                if (0 > dy) rectf.Height = src.Height = img.Height; else src.Height = (int)rectf.Height;

            }
            else if (DataGridViewImageCellLayout.Stretch == imagecell.ImageLayout)
            {

                src.Width = img.Width;
                src.Height = img.Height;


                dx = 0;
                dy = 0;
            }
            else
            {

                src.Width = img.Width;
                src.Height = img.Height;

                float vertscale = rectf.Height / src.Height;
                float horzscale = rectf.Width / src.Width;
                float scale;


                if (vertscale > horzscale)
                {

                    scale = horzscale;
                    dx = 0;
                    dy = (int)((src.Height * scale) - rectf.Height);
                }
                else
                {

                    scale = vertscale;
                    dy = 0;
                    dx = (int)((src.Width * scale) - rectf.Width);
                }

                rectf.Width = src.Width * scale;
                rectf.Height = src.Height * scale;
            }

            switch (imagecell.InheritedStyle.Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    if (0 > dy) rectf.Y -= dy; else src.Y = dy;
                    if (0 > dx) rectf.X -= dx / 2; else src.X = dx / 2;
                    break;
                case DataGridViewContentAlignment.BottomLeft:
                    if (0 > dy) rectf.Y -= dy; else src.Y = dy;
                    src.X = 0;
                    break;
                case DataGridViewContentAlignment.BottomRight:
                    if (0 > dy) rectf.Y -= dy; else src.Y = dy;
                    if (0 > dx) rectf.X -= dx; else src.X = dx;
                    break;
                case DataGridViewContentAlignment.MiddleCenter:
                    if (0 > dy) rectf.Y -= dy / 2; else src.Y = dy / 2;
                    if (0 > dx) rectf.X -= dx / 2; else src.X = dx / 2;
                    break;
                case DataGridViewContentAlignment.MiddleLeft:
                    if (0 > dy) rectf.Y -= dy / 2; else src.Y = dy / 2;
                    src.X = 0;
                    break;
                case DataGridViewContentAlignment.MiddleRight:
                    if (0 > dy) rectf.Y -= dy / 2; else src.Y = dy / 2;
                    if (0 > dx) rectf.X -= dx; else src.X = dx;
                    break;
                case DataGridViewContentAlignment.TopCenter:
                    src.Y = 0;
                    if (0 > dx) rectf.X -= dx / 2; else src.X = dx / 2;
                    break;
                case DataGridViewContentAlignment.TopLeft:
                    src.Y = 0;
                    src.X = 0;
                    break;
                case DataGridViewContentAlignment.TopRight:
                    src.Y = 0;
                    if (0 > dx) rectf.X -= dx; else src.X = dx;
                    break;
                case DataGridViewContentAlignment.NotSet:
                    if (0 > dy) rectf.Y -= dy / 2; else src.Y = dy / 2;
                    if (0 > dx) rectf.X -= dx / 2; else src.X = dx / 2;
                    break;
            }


            g.DrawImage(img, rectf, src, GraphicsUnit.Pixel);
        }
    }
}
