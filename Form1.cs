using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

using MySql.Data.MySqlClient;
using MySql.Data.Types;
using WatiN.Core;


namespace WMTest
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private int _counter;
        private IE ie;
        private DataSet csvDataSet;
        private string delDir; //put here due to cross threading issue

        public Form1()
        {
            InitializeComponent();            
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString().Remove(0,8);
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Navigate( toolStripTextBox1.Text );
            }
        }

        // Navigates to the given URL if it is valid.
        private void Navigate(String address)
        {
            if(String.IsNullOrEmpty( address )) return;
            try
            {
                webBrowser1.Navigate( new Uri( address ) );
            }
            catch(System.UriFormatException)
            {
                return;
            }
        }

        private void toolStripbrnUp_Click(object sender, EventArgs e)
        {
            //Navigate( Directory.GetParent(toolStripTextBox1.Text.Remove(0,8)).ToString() );
            Navigate( Directory.GetParent( toolStripTextBox1.Text ).ToString() );
        }

        private void lnkSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if(dlgResult == DialogResult.OK)
                cboSource.Text = folderBrowserDlg.SelectedPath;
        }

        private void lnkOutput_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if(dlgResult == DialogResult.OK)
                cboOutput.Text = folderBrowserDlg.SelectedPath;
        }

        private void lnkPST_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            //if(dlgResult == DialogResult.OK)
            //    cboPST.Text = folderBrowserDlg.SelectedPath;
        }

        /// <summary>
        /// Not only initial UI. But also verify user input.
        /// </summary>
        /// <returns></returns>
        private void initUI()
        {
            txtActualPst.BackColor = txtExpectedPst.BackColor; // default color
            txtActualFile.BackColor = txtExpectedPst.BackColor;
            txtActualProp.BackColor = txtExpectedPst.BackColor;

            cboSource.BackColor = cboURL.BackColor;
            cboOutput.BackColor = cboURL.BackColor;
            //cboPST.BackColor = cboURL.BackColor;

            txtExpectedFile.Text = "0";
            txtExpectedProp.Text = "0";
            txtExpectedPst.Text = "0";
            txtExpectedSrc.Text = "0";

            txtActualProp.Text = "0";
            txtActualFile.Text = "0";
            txtActualSrc.Text = "0";
            txtActualPst.Text = "0";

            txtExpectedProp.Refresh();
            txtExpectedFile.Refresh();
            txtExpectedPst.Refresh();
            txtExpectedSrc.Refresh();

            txtActualProp.Refresh();
            txtActualFile.Refresh();
            txtActualSrc.Refresh();
            txtActualPst.Refresh();

            cboSource.Refresh();
            cboOutput.Refresh();
            //cboPST.Refresh();

        }//end of initUI

        /// <summary>
        /// Verify user input. Assume everything OK - true. 
        /// </summary>
        /// <returns>true for OK; false for invalid input</returns>
        private bool VerifyUserInput()
        {
            bool rv = true; // everything OK

            if(!Directory.Exists( cboSource.Text ))
            {
                cboSource.BackColor = Color.YellowGreen;
                rv = false;
            }

            if(!Directory.Exists( cboOutput.Text ))
            {
                cboOutput.BackColor = Color.YellowGreen;
                rv = false;
            }

            //if(!Directory.Exists( cboPST.Text ))
            //{
            //    cboPST.BackColor = Color.YellowGreen;
            //    rv = false;
            //}

            return (rv);
        }//end of VerifyUserInput

        //[STAThreadAttribute]
        private void btnAutoWeb_Click(object sender, EventArgs e)
        {
            // Open a new Internet Explorer window and goto the google website.
            // IE ie = new IE( "http://localhost:9999/aciserver4j" );
            if(ie != null)
                ie.Close();
            Thread.Sleep( 1000 );

            if(rdoOffline.Checked)
                OfflineProcessing();
            else
                if(rdoOnline.Checked)
                    OnlineProcessing();

            //Thread.Sleep( 5000 );
            //ie.Close();
        }//end of btnAutoWeb_Click

        private void OnlineProcessing()
        {
            ie = new IE( cboURL.Text + "/dlhOnlineDashboard.do?method=showDlhOnlineDashboard" );
            //ie.Link( Find.ByUrl( cboURL.Text + "/dlhOnlineDashboard.do?method=showDlhOnlineDashboard" ) ).Click();
            ie.Link( Find.ByUrl( cboURL.Text + "/dlhOnlineDashboard.do?method=showScanDirectories" ) ).Click();
            ie.Link( Find.ById( "dialog-link-addDlhScanDirectory" ) ).Click();
            ie.TextField( Find.ByName( "addScanDirectoryPath" ) ).TypeText( cboSource.Text );
            ie.TextField( Find.ByName( "addScanDirectoryOutputPath" ) ).TypeText( cboOutput.Text );
            ie.Div( Find.ById( "dialog-addDlhScanDirectory" ) ).Image( Find.BySrc( cboURL.Text + "/images/accept.png" ) ).Click();
        }//end of OnlineProcessing()

        private void OfflineProcessing()
        {
            ie = new IE( cboURL.Text );
            ie.Link( Find.ByUrl( cboURL.Text + "/dlhOfflineDashboard.do?method=showScanDirectories" ) ).Click();
            ie.Link( Find.ById( "dialog-link-addDlhScanDirectory" ) ).Click();
            ie.TextField( Find.ByName( "addScanDirectoryPath" ) ).TypeText( cboSource.Text );
            ie.TextField( Find.ByName( "addScanDirectoryOutputPath" ) ).TypeText( cboOutput.Text );
            ie.Div( Find.ById( "dialog-addDlhScanDirectory" ) ).Image( Find.BySrc( cboURL.Text + "/images/accept.png" ) ).Click();

        }//end of OfflineProcessing

        /// <summary>
        /// Handle entire counting process that include display info.
        /// 1. Get the expected results
        /// 2. Counting offline and online .file and .properties from FS.
        /// 3. Compare the results
        /// 4. Display the results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCount_Click(object sender, EventArgs e)
        {
            initUI();

            if(!VerifyUserInput())
                return;

            this.Cursor = Cursors.WaitCursor;

            if(!GetExpectedResult())
                return;

            txtExpectedProp.Refresh(); // if everything OK, update UI
            txtExpectedFile.Refresh();
            txtExpectedPst.Refresh();
            txtExpectedSrc.Refresh();

            _counter = 0; // reset counter
            DirSearch( cboOutput.Text, "*.file" );
            txtActualFile.Text = _counter.ToString( CultureInfo.CurrentCulture );

            _counter = 0; // reset counter
            DirSearch( cboOutput.Text, "*.properties" );
            txtActualProp.Text = _counter.ToString( CultureInfo.CurrentCulture );

            txtActualPst.Text = CountPSTFromFS(GetDoneFilename(cboSource.Text)).ToString(CultureInfo.CurrentCulture);

            CompareResults();

            // Not neccessary
            //txtActualProp.Refresh();
            //txtActualFile.Refresh();
            //txtActualSrc.Refresh();
            //txtActualPst.Refresh();            

            this.Cursor = Cursors.Default;
        }//end of btnCount_Click

        /// <summary>
        /// Compare the result if not same highlight it.
        /// </summary>
        private void CompareResults()
        {
            if(txtExpectedPst.Text != txtActualPst.Text)
                txtActualPst.BackColor = Color.Yellow;

            if(txtExpectedFile.Text != txtActualFile.Text)
                txtActualFile.BackColor = Color.Yellow;

            if(txtExpectedProp.Text != txtActualProp.Text)
                txtActualProp.BackColor = Color.Yellow;

        }//end of CompareResult

        /// <summary>
        /// Get the PST count from mysql db table: wamu_dlh_inventory based on the barcode.
        /// e.g.: SELECT count(*) FROM test.wamu_dlh_pst_inventory where tapeinventorybarcode='JPMCW000677';
        /// </summary>
        /// <returns></returns>
        private string GetPSTCountFromMySQL()
        {
            string rv = "0";
            // TO DO: Modularize it and remove all the hard code value, and validate user input
            string barCode = GetElements( "//HardDisk/@barcode", GetDoneFilename( cboSource.Text ) );
            string host = "127.0.0.1";
            string database = txtDatabase.Text;
            string user = txtUserID.Text;
            string password = txtPassword.Text;

            string strSQL = "SELECT count(*) FROM test.wamu_dlh_pst_inventory where tapeinventorybarcode='" + barCode + "'";

            string strProvider = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;

            try
            {
                MySqlConnection mysqlCon = new MySqlConnection( strProvider );
                mysqlCon.Open();

                if(mysqlCon.State.ToString() == "Open")
                {
                    MySqlCommand mysqlCmd = new MySqlCommand( strSQL, mysqlCon );
                    MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();

                    //Expect one result and get the first one
                    if(mysqlReader.Read())
                        rv = mysqlReader.GetString( 0 );

                    // Save for reference - read multiple entries
                    //while(mysqlReader.Read())
                    //{
                    //    //Console.WriteLine(mysqlReader.GetInt32(0) + "\t" + mysqlReader.GetString(1) + "\t" + mysqlReader.GetString(2));
                    //    Debug.WriteLine( mysqlReader.GetString( 0 ) );
                    //}
                }//end of if
                
                mysqlCon.Close();
            }//end of try
            catch(Exception er)
            {
                MessageBox.Show( er.Message, "GetPSTCountFromMySQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }

            return (rv);
        }//end of GetPSTCountFromMySQL

        /// <summary>
        /// Get the bar code from done file. Pass the done file into it.
        /// Count the pst from file system based on the file path in MySQL.
        /// Check does the file exist from the FS.
        /// </summary>
        private int CountPSTFromFS(string filename)
        {
            int rv = 0; // default 0 count
            // TO DO: Modularize it and remove all the hard code value, and validate user input
            string barCode = GetElements( "//HardDisk/@barcode", filename );
            string host = "127.0.0.1";
            string database = txtDatabase.Text;
            string user = txtUserID.Text;
            string password = txtPassword.Text;
            string strSQL = "SELECT filepath FROM test.wamu_dlh_pst_inventory where tapeinventorybarcode='" + barCode + "'";

            string strProvider = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;

            try
            {
                MySqlConnection mysqlCon = new MySqlConnection( strProvider );
                mysqlCon.Open();

                if(mysqlCon.State.ToString() == "Open")
                {
                    MySqlCommand mysqlCmd = new MySqlCommand( strSQL, mysqlCon );
                    MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();

                    while(mysqlReader.Read())
                    {
                        //Debug.WriteLine( mysqlReader.GetInt32( 0 ) + "\t" + mysqlReader.GetString( 1 ) + "\t" + mysqlReader.GetString( 2 ) );
                        if(File.Exists( mysqlReader.GetString( 0 ) ))
                            rv++;
                    }
                }//end of if

                mysqlCon.Close();
            }//end of try
            catch(Exception er)
            {
                MessageBox.Show( er.Message, "GetPSTCountFromMySQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }

            return (rv);
        }//end of CountPSTFromFS
        /// <summary>
        /// Read the expected result file per test case. (From GUI cboSource)
        /// If the expected result file doesn't exist, read the result from done file.
        /// Other filled with zero.
        /// Assume only one expected result file. If not, pick the first one
        /// </summary>
        private bool GetExpectedResult()
        {
            bool rv = true; // assume good.
            try
            {
                string[] fn = Directory.GetFiles( cboSource.Text, "*Expected.txt" );

                if(fn.Length == 0) // file not found
                {
                    txtExpectedSrc.Text = GetElements( "/report/Processed", GetDoneFilename(cboSource.Text) ); // "/report/Processed" XML structure from *.done file
                    txtExpectedPst.Text = GetPSTCountFromMySQL();
                }
                else
                {
                    string line;
                    using(StreamReader sr = new StreamReader( fn[0] ))
                    {
                        while((line = sr.ReadLine()) != null)
                        {
                            string[] tmpStr = line.Split( new char[] { '=' } );
                            switch(tmpStr[0].Trim())
                            {
                                case "Source":
                                    txtExpectedSrc.Text = tmpStr[1];
                                    break;
                                case "PST":
                                    txtExpectedPst.Text = tmpStr[1];
                                    break;
                                case "Files":
                                    txtExpectedFile.Text = tmpStr[1];
                                    break;
                                case "Properties":
                                    txtExpectedProp.Text = tmpStr[1];
                                    break;
                            }//end of switch
                        }//end of while
                    }//end of using
                }//end of else
            }
            catch(IOException ioex)
            {
                MessageBox.Show( ioex.Message, "IO Excpetion", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
                rv = false; // bad bad bad
            }

            return (rv);
        }//end of GetExpectedResult

        /// <summary>
        /// Search files in sub-directory. Files in current directory will not search.
        /// </summary>
        /// <param name="sDir"></param>
        public void DirSearch(string sDir, string patten)
        {
            try
            {
                foreach(string d in Directory.GetDirectories( sDir ))
                {
                    FileSearch( d, patten );
                    DirSearch( d, patten );
                }
            }
            catch(System.Exception excpt)
            {
                MessageBox.Show( excpt.Message, "DirSearch", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
                return;
            }          
        }//end of DirSearch

        /// <summary>
        /// Search files in the current directory.
        /// </summary>
        /// <param name="cDir"></param>
        public void FileSearch(string cDir, string searchPatten)
        {
            try
            {
                _counter += Directory.GetFiles( cDir, searchPatten ).Length;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show( ex.Message, "FileSearch", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }
        }//end of fileSearch

        /// <summary>
        /// Pass the folder that contain the done file.
        /// Assume there is ONLY one done file and only return the first found
        /// </summary>
        /// <param name="cDir">The full path folder that contain the done file</param>
        /// <returns></returns>
        public string GetDoneFilename( string cDir )
        {
            string[] fn = Directory.GetFiles( cDir, "*.done" );
            return (fn[0]);// only return the first one
        }//end of GetDoneFilename

        /// <summary>
        /// Return a element of a XML file
        /// </summary>
        /// <param name="expression">XPaht expression</param>
        /// <param name="fileName">Full paht file name</param>
        /// <returns>string</returns>
        private string GetElements(string expression, string fileName)
        {
            string rv = null;
            //string fileName = @"Z:\wamuTestData\data\dlh\318993-DLH SOURCE\318993.done";
            //string fileName = GetDoneFilename( cboSource.Text ); // TO DO: read from file contain the path.
            XPathDocument doc = new XPathDocument( fileName );
            XPathNavigator nav = doc.CreateNavigator();

            // Compile a standard XPath expression
            XPathExpression expr;
            expr = nav.Compile( expression );
            XPathNodeIterator iterator = nav.Select( expr );

            try
            {
                while(iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    //txtExpectedSrc.Text = nav2.Value;
                    rv = nav2.Value;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message, "GetElements", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }

            return (rv);
        }//end of GetElements

        /// <summary>
        /// Importing Data From CSV File. 
        /// You can get connected to driver either by using DSN or connection string
        /// NOTE: 
        /// filetable - refer to the input csv short file name and represent table name in data set.
        /// TC1 - refer to the name of the sheet in csv file. It is good for multiple sheet (tables) in data set.
        /// </summary>
        /// <param name="filetable">Input SHORT csv file name: Will parse for table name and schema location</param>
        /// <param name="workingFolder">Forgot what it is. Just pass the working folder path here</param>
        /// <returns></returns>
        public DataSet connectCSV(string filetable, string workingFolder)
        {
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            System.Data.Odbc.OdbcDataAdapter obj_oledb_da;

            try
            {
                // Create a connection string as below, if you want to use DSN less connection. The DBQ attribute sets the path of directory which contains CSV files
                string strConnString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + workingFolder.Trim() + ";Extensions=asc,csv,tab,txt;Persist Security Info=False";
                string sql_select;
                System.Data.Odbc.OdbcConnection conn;

                //Create connection to CSV file
                conn = new System.Data.Odbc.OdbcConnection( strConnString.Trim() );

                // SAVE - For creating a connection using DSN, use following line
                // conn	=	new System.Data.Odbc.OdbcConnection(DSN="MyDSN");

                conn.Open(); //Open the connection                 
                sql_select = "select * from [" + filetable + "]"; //Fetch records from CSV - filetable is the file name
                obj_oledb_da = new System.Data.Odbc.OdbcDataAdapter( sql_select, conn );
                obj_oledb_da.Fill( ds, Path.GetFileNameWithoutExtension(filetable) ); //Fill dataset with the records from CSV file; DefFile is the name of the sheet
                //obj_oledb_da.Fill( ds ); //Fill dataset with the records from CSV file; TC1 is the name of the sheet

                #region kentsave
                //int x = ds.Tables[0].Columns.Count;
                //string str = ds.Tables[0].Columns[3].ToString();
                //string str2 = ds.Tables[0].Columns[3].ColumnName;
                //string str3 = ds.Tables[0].Rows[9]["BCC"].ToString();

                //Set the datagrid properties
                //dataGridView.DataSource = ds;
                //dataGridView.DataMember = "DefFile"; // name of the sheet    

                //for(int i = 0; i < lstFailCell.Length; i++)
                //{
                //    DataGridViewCell cell = dataGridView[lstFailCell[i].X, lstFailCell[i].Y];
                //    cell.Style.BackColor = Color.YellowGreen; ;
                //}
                #endregion

                //Close Connection to CSV file
                conn.Close();
            }
            catch(OdbcException e)
            {
                string errMsg = "";

                for(int i = 0; i < e.Errors.Count; i++)
                {
                    errMsg += "Index #" + i + "\n" +
                              "Message: " + e.Errors[i].Message + "\n" +
                              "NativeError: " + e.Errors[i].NativeError.ToString( CultureInfo.CurrentCulture ) + "\n" +
                              "Source: " + e.Errors[i].Source + "\n" +
                              "SQL: " + e.Errors[i].SQLState + "\n";
                }

                MessageBox.Show( errMsg, "connectCSV", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }//end of catch - OdbcException
            //catch(Exception ex2) //Error
            //{
            //    MessageBox.Show( ex2.Message );
            //}
            return ds;
        }//end of ConnectCSV

        /// <summary>
        /// Import the CSV into Data View
        /// </summary>
        /// <param name="fileName">Short file name of the import CSV</param>
        private void importCSVData(string fileName)
        {
            try
            {
                writeSchema();
                csvDataSet = connectCSV( fileName, Path.GetDirectoryName(cboInFile.Text) );

                // Get Column header
                string[] headers = new string[csvDataSet.Tables[0].Columns.Count];
                for(int i = 0; i < csvDataSet.Tables[0].Columns.Count; i++)
                {
                    headers[i] = csvDataSet.Tables[0].Columns[i].ColumnName;
                }

                //Set the datagrid properties
                dataGridView.DataSource = csvDataSet;
                //dataGridView.DataMember = "DefFile"; // name of the sheet
                dataGridView.DataMember = Path.GetFileNameWithoutExtension(fileName); // name of the sheet

                for(int i = 0; i < csvDataSet.Tables[0].Rows.Count; i++)
                {
                    if(csvDataSet.Tables[0].Rows[i][0].ToString().Contains( "#TC" ))
                        dataGridView.Rows[i].Visible = false;
                }//end of for

                dataGridView.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message, "importCSVData", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }
            finally
            { }
        }//end of importCSVData

        /// <summary>
        /// Schema.ini File (Text File Driver)
        /// When the Text driver is used, the format of the text file is determined by using a
        /// schema information file. The schema information file, which is always named Schema.ini
        /// and always kept in the same directory as the text data source, provides the IISAM 
        /// with information about the general format of the file, the column name and data type
        /// information, and a number of other data characteristics
        /// </summary>
        private void writeSchema()
        {
            try
            {
                FileStream fsOutput = new FileStream( "C:\\schema.ini", FileMode.Create, FileAccess.Write );
                StreamWriter srOutput = new StreamWriter( fsOutput );
                string s1, s2, s3, s4, s5;
                s1 = "[schema]";
                s2 = "ColNameHeader=true";
                s3 = "Format=CSVDelimited";
                s4 = "MaxScanRows=100";
                s5 = "CharacterSet=OEM";
                //srOutput.WriteLine(s1.ToString() + '\n' + s2.ToString() + '\n' + s3.ToString() + '\n' + s4.ToString() + '\n' + s5.ToString());
                srOutput.WriteLine( s1.ToString( CultureInfo.CurrentCulture ) + "\r\n" + s2.ToString( CultureInfo.CurrentCulture ) + "\r\n" + s3.ToString() + "\r\n" + s4.ToString() + "\r\n" + s5.ToString( CultureInfo.CurrentCulture ) );
                srOutput.Close();
                fsOutput.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message, "writeSchema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }
            finally
            { }
        }//end of writeSchema

        private void btnAutoCount_Click(object sender, EventArgs e)
        {
            Debug.WriteLine( "btnAutoCount_Click" );
            this.Cursor = Cursors.WaitCursor;

            switch(Path.GetFileName(cboInFile.Text))
            {
                case "Offline.csv":
                    AutoCountOffline();
                    break;
                case "Online.csv":
                    AutoCountOnline();
                    break;
            }//end of switch

            this.Cursor = Cursors.Default;
        }//end of btnAutoCount_Click

        /// <summary>
        /// Handle counting, compare and display offline test result
        /// </summary>
        private void AutoCountOffline()
        {
            try
            {
                FileInfo fi = new FileInfo( cboInFile.Text );
                importCSVData( fi.Name );

            }//end of try
            catch(IOException ioex)
            {
                MessageBox.Show( ioex.Message, "IO Exception" );
            }

            for(int i = 0; i < dataGridView.Rows.Count - 1; i++) // minus header
            {
                if(!Directory.Exists( dataGridView.Rows[i].Cells["Output Path"].Value.ToString() ))
                {
                    dataGridView.Rows[i].Cells["Actual File"].Value = "N/A";
                    dataGridView.Rows[i].Cells["Actual Prop"].Value = "N/A";
                    dataGridView["Actual File", i].Style.BackColor = Color.YellowGreen;
                    dataGridView["Actual Prop", i].Style.BackColor = Color.YellowGreen;
                    continue;
                }

                _counter = 0; // reset counter
                DirSearch( dataGridView.Rows[i].Cells["Output Path"].Value.ToString(), "*.file" );
                dataGridView.Rows[i].Cells["Actual File"].Value = _counter.ToString( CultureInfo.CurrentCulture );
                if(_counter != int.Parse( dataGridView["Expected File", i].Value.ToString(), CultureInfo.CurrentCulture ))
                    dataGridView["Actual File", i].Style.BackColor = Color.Yellow;

                _counter = 0; // reset counter
                DirSearch( dataGridView.Rows[i].Cells["Output Path"].Value.ToString(), "*.properties" );
                dataGridView.Rows[i].Cells["Actual Prop"].Value = _counter.ToString( CultureInfo.CurrentCulture );
                if(_counter != int.Parse( dataGridView["Expected Prop", i].Value.ToString(), CultureInfo.CurrentCulture ))
                    dataGridView["Actual Prop", i].Style.BackColor = Color.Yellow;

                //_counter = 0; // reset counter
                //DirSearch( dataGridView.Rows[i].Cells["Output Path"].Value.ToString(), "*.pst" );
                _counter = CountPSTFromFS( GetDoneFilename( dataGridView.Rows[i].Cells["Input Path"].Value.ToString() ) );
                dataGridView.Rows[i].Cells["Actual PST"].Value = _counter.ToString( CultureInfo.CurrentCulture );
                //if(_counter != int.Parse( dataGridView["Expected pst", i].Value.ToString() ))
                if(_counter != int.Parse( dataGridView[8, i].Value.ToString(), CultureInfo.CurrentCulture )) // don't know why cannot use "Expected PST". ie: use 8
                    dataGridView["Actual PST", i].Style.BackColor = Color.Yellow;

                string inPath = dataGridView.Rows[i].Cells["input Path"].Value.ToString();
                if(Directory.Exists( inPath ))
                {
                    string barCode = GetElements( "//HardDisk/@barcode", GetDoneFilename( inPath ) );
                    if(barCode != null)
                    {
                        if(IsLegalHoldFromMySQL( barCode ))
                            dataGridView.Rows[i].Cells["Legal Hold"].Value = "Y";
                        else
                            dataGridView.Rows[i].Cells["Legal Hold"].Value = "N";
                    }//end of if
                    else
                        dataGridView.Rows[i].Cells["Legal Hold"].Value = "No Barcode";
                }
                else
                    dataGridView.Rows[i].Cells["Legal Hold"].Value = "N/A";

                dataGridView.Refresh();
            }//end of for
        }//end of AutoCountOffline

        private void AutoCountOnline()
        {
            int tmpSkipFileCnt;
            int tmpSkipPropCnt;
            int tmpTFileCnt;
            int tmpTPropCnt;
            decimal pstCnt;
            decimal nsrlCnt;
            decimal marimbaCnt;

            try
            {
                FileInfo fi = new FileInfo( cboInFile.Text );
                importCSVData( fi.Name );

            }//end of try
            catch(IOException ioex)
            {
                MessageBox.Show( ioex.Message, "IO Exception" );
            }

            for(int i = 0; i < dataGridView.Rows.Count - 1; i++) // minus header
            {
                if(!Directory.Exists( dataGridView.Rows[i].Cells["Output Path"].Value.ToString() ))
                {
                    dataGridView.Rows[i].Cells["Total"].Value = "N/A";
                    dataGridView.Rows[i].Cells["File"].Value = "N/A";
                    dataGridView.Rows[i].Cells["Prop"].Value = "N/A";
                    dataGridView.Rows[i].Cells["NSRL"].Value = "N/A";
                    dataGridView.Rows[i].Cells["Marimba"].Value = "N/A";
                    dataGridView.Rows[i].Cells["PST"].Value = "N/A";
                    dataGridView.Rows[i].Cells["Skip Folder"].Value = "N/A";
                    dataGridView.Rows[i].Cells["Legal Hold"].Value = "N/A";
                    dataGridView["#Test case", i].Style.BackColor = Color.YellowGreen;
                    continue;
                }

                pstCnt = GetOnlinePSTCountFromMySQL( i );
                nsrlCnt = GetOnlineNsrlCountFromMySQL( i );
                marimbaCnt = GetOnlineMarimbaCountFromMySQL( i );

                dataGridView.Rows[i].Cells["PST"].Value = pstCnt.ToString( CultureInfo.CurrentCulture );
                dataGridView.Rows[i].Cells["NSRL"].Value = nsrlCnt.ToString( CultureInfo.CurrentCulture );
                dataGridView.Rows[i].Cells["Marimba"].Value = marimbaCnt.ToString( CultureInfo.CurrentCulture );

                try
                {
                    DirectoryInfo di = new DirectoryInfo( dataGridView.Rows[i].Cells["Output Path"].Value.ToString() );

                    //Get subdirectories that start with dlh-online*
                    DirectoryInfo[] dis = di.GetDirectories( "dlh-online*" );

                    tmpSkipFileCnt = 0;
                    tmpSkipPropCnt = 0;
                    tmpTFileCnt = 0;
                    tmpTPropCnt = 0;
                    for(int j = 0; j < dis.Length; j++)
                    {
                        DirectoryInfo[] skipPath = dis[j].GetDirectories( "skipped*" ); // assume only one directory
                        DirectoryInfo[] tPath = dis[j].GetDirectories( "t_*" );

                        Debug.WriteLine( "tPath: " + tPath[j].FullName );
                        _counter = 0;
                        DirSearch( skipPath[0].FullName, "*.file" );
                        tmpSkipFileCnt += _counter;

                        //_counter = 0;
                        //DirSearch( skipPath[0].FullName, "*.properties" );
                        //tmpSkipPropCnt += _counter;

                        _counter = 0;
                        DirSearch( tPath[0].FullName, "*.file" );
                        tmpTFileCnt += _counter;

                        _counter = 0;
                        DirSearch( tPath[0].FullName, "*.properties" );
                        tmpTPropCnt += _counter;
                    }//end of for

                    dataGridView.Rows[i].Cells["File"].Value = tmpTFileCnt.ToString( CultureInfo.CurrentCulture );
                    dataGridView.Rows[i].Cells["Prop"].Value = tmpTPropCnt.ToString( CultureInfo.CurrentCulture );
                    dataGridView.Rows[i].Cells["Skip Folder"].Value = tmpSkipFileCnt.ToString( CultureInfo.CurrentCulture );

                    int total = (int)pstCnt + (int)nsrlCnt + (int)marimbaCnt + tmpTFileCnt;
                    dataGridView.Rows[i].Cells["Total"].Value = total.ToString( CultureInfo.CurrentCulture );

                    if(total != int.Parse( dataGridView[4, i].Value.ToString(), CultureInfo.CurrentCulture ))
                        dataGridView["Expected File", i].Style.BackColor = Color.Yellow;


                }//end oftry
                catch(IOException ioex)
                {
                }


                #region delete it later
                //    _counter = 0; // reset counter
            //    DirSearch( dataGridView.Rows[i].Cells["Output Path"].Value.ToString(), "*.file" );
            //    dataGridView.Rows[i].Cells["Actual File"].Value = _counter.ToString( CultureInfo.CurrentCulture );
            //    if(_counter != int.Parse( dataGridView["Expected File", i].Value.ToString(), CultureInfo.CurrentCulture ))
            //        dataGridView["Actual File", i].Style.BackColor = Color.Yellow;

            //    _counter = 0; // reset counter
            //    DirSearch( dataGridView.Rows[i].Cells["Output Path"].Value.ToString(), "*.properties" );
            //    dataGridView.Rows[i].Cells["Actual Prop"].Value = _counter.ToString( CultureInfo.CurrentCulture );
            //    if(_counter != int.Parse( dataGridView["Expected Prop", i].Value.ToString(), CultureInfo.CurrentCulture ))
            //        dataGridView["Actual Prop", i].Style.BackColor = Color.Yellow;

            //    //_counter = 0; // reset counter
            //    //DirSearch( dataGridView.Rows[i].Cells["Output Path"].Value.ToString(), "*.pst" );
            //    _counter = CountPSTFromFS( GetDoneFilename( dataGridView.Rows[i].Cells["Input Path"].Value.ToString() ) );
            //    dataGridView.Rows[i].Cells["Actual PST"].Value = _counter.ToString( CultureInfo.CurrentCulture );
            //    //if(_counter != int.Parse( dataGridView["Expected pst", i].Value.ToString() ))
            //    if(_counter != int.Parse( dataGridView[8, i].Value.ToString(), CultureInfo.CurrentCulture )) // don't know why cannot use "Expected PST". ie: use 8
            //        dataGridView["Actual PST", i].Style.BackColor = Color.Yellow;

            //    string inPath = dataGridView.Rows[i].Cells["input Path"].Value.ToString();
            //    if(Directory.Exists( inPath ))
            //    {
            //        string barCode = GetElements( "//HardDisk/@barcode", GetDoneFilename( inPath ) );
            //        if(barCode != null)
            //        {
            //            if(IsLegalHoldFromMySQL( barCode ))
            //                dataGridView.Rows[i].Cells["Legal Hold"].Value = "Y";
            //            else
            //                dataGridView.Rows[i].Cells["Legal Hold"].Value = "N";
            //        }//end of if
            //        else
            //            dataGridView.Rows[i].Cells["Legal Hold"].Value = "No Barcode";
            //    }
            //    else
                //        dataGridView.Rows[i].Cells["Legal Hold"].Value = "N/A";
                #endregion
                dataGridView.Refresh();
            }//end of for
        }//end of AutoCountOnline

        private void btnAutoTest_Click(object sender, EventArgs e)
        {
            switch(Path.GetFileName(cboInFile.Text))
            {
                case "Offline.csv":
                    OfflineProcess();
                    break;
                case "Online.csv":
                    OnlineProcess();
                    break;
            }//end of switch
        }//end of btnAutoTest_Click

        /// <summary>
        /// Handle the offline test case
        /// </summary>
        private void OfflineProcess()
        {
            try
            {
                delDir = "C:\\wamuOut\\Offline";
                if(Directory.Exists( delDir ))
                    bgwDeleteFolders.RunWorkerAsync();

                if(ie != null)
                    ie.Close();

                Thread.Sleep( 1000 );
                ie = new IE( cboURL.Text );
                ie.Link( Find.ByUrl( "http://localhost:9999/aciserver4j/dlhOfflineDashboard.do?method=showScanDirectories" ) ).Click();

                using(StreamReader sr = new StreamReader( cboInFile.Text ))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        if(line[0] != '#') //skip all comment
                        {
                            string[] splitStr = line.Split( new char[] { ',' } );

                            ie.Link( Find.ById( "dialog-link-addDlhScanDirectory" ) ).Click();
                            ie.TextField( Find.ByName( "addScanDirectoryPath" ) ).TypeText( splitStr[1] );
                            ie.TextField( Find.ByName( "addScanDirectoryOutputPath" ) ).TypeText( splitStr[2] );
                            ie.Div( Find.ById( "dialog-addDlhScanDirectory" ) ).Image( Find.BySrc( cboURL.Text + "/images/accept.png" ) ).Click();
                            Thread.Sleep( 1000 );

                        }//end of if
                    }//end of while
                }//end of using
            }//end of try
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message, "Auto offline", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }

            Debug.WriteLine( "Done on Offline Process." );
        }//end of OfflineProcess

        private void OnlineProcess()
        {
            try
            {
                delDir = "C:\\wamuOut\\Online";
                if(Directory.Exists( delDir ))
                    bgwDeleteFolders.RunWorkerAsync();

                if(ie != null)
                    ie.Close();

                Thread.Sleep( 1000 );
                ie = new IE( cboURL.Text + "/dlhOnlineDashboard.do?method=showDlhOnlineDashboard" );
                using(StreamReader sr = new StreamReader( cboInFile.Text ))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        if(line[0] != '#') //skip all comment
                        {
                            string[] splitStr = line.Split( new char[] { ',' } );

                            ie.Link( Find.ByUrl( cboURL.Text + "/dlhOnlineDashboard.do?method=showScanDirectories" ) ).Click();
                            ie.Link( Find.ById( "dialog-link-addDlhScanDirectory" ) ).Click();
                            ie.TextField( Find.ByName( "addScanDirectoryPath" ) ).TypeText( splitStr[1] );
                            ie.TextField( Find.ByName( "addScanDirectoryOutputPath" ) ).TypeText( splitStr[2] );
                            ie.TextField( Find.ByName( "dlhOnlineBarCodes" ) ).TypeText( splitStr[3] );
                            ie.Div( Find.ById( "dialog-addDlhScanDirectory" ) ).Image( Find.BySrc( cboURL.Text + "/images/accept.png" ) ).Click();
                            Thread.Sleep( 5000 );

                        }//end of if
                    }//end of while
                }//end of using
            }//end of try
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message, "Auto offline", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }
        }//end of OnlineProcess

        private void lnkInput_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dlgResult = openFileDlg.ShowDialog();
            if(dlgResult == DialogResult.OK)
            {
                cboInFile.Text = openFileDlg.FileName;
            }
        }//end of lnkInput_LinkClicked

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delDir = cboOutput.Text;
            bgwDeleteFolders.RunWorkerAsync();            
        }//end of btnDelete_Click

        /// <summary>
        /// 1. Rename the folder for deleteion.
        /// 2. Delete the folder
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private string DeleteFolders(BackgroundWorker bw, DoWorkEventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo( delDir );
                di.MoveTo( di.FullName + "_DeleteMe" );
                //di = new DirectoryInfo( delDir + "_DeleteMe" );
                di.Delete( true );

                return ("Done");
            }
            catch(IOException ioex)
            {
                MessageBox.Show( ioex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
                return ("Error"); //error
            }
        }//end of DeleteFolders

        private void bgwDeleteFolders_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;

            // Extract the argument.
            //int arg = (int)e.Argument;

            // Start the time-consuming operation.
            e.Result = DeleteFolders( bw, e );

            // If the operation was canceled by the user, set the DoWorkEventArgs.Cancel property to true.
            if(bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }//end of bgwDeleteFolders_DoWork

        /// <summary>
        /// TO DO: Not working yet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwDeleteFolders_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // NOT Working: TO DO
            txtDisplay.Text = e.ProgressPercentage.ToString( CultureInfo.CurrentCulture ) + " " + e.UserState.ToString();
            txtDisplay.Refresh();
        }//end of bgwDeleteFolders_ProgressChanged

        private void bgwDeleteFolders_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                // The user canceled the operation.
                MessageBox.Show( "Operation was canceled", "Background delete folder completed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }
            else if(e.Error != null)
            {
                // There was an error during the operation.
                string msg = String.Format( CultureInfo.CurrentCulture, "An error occurred: {0}", e.Error.Message );
                MessageBox.Show( msg, "BK work completed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }
            else
            {
                // The operation completed normally.
                string msg = String.Format( CultureInfo.CurrentCulture, "Delete Folder {0}", e.Result.ToString() );
                MessageBox.Show( msg, "BK work completed", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }

        }

        /// <summary>
        /// Check the status of legal hold for specific data set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLegalHold_Click(object sender, EventArgs e)
        {
            try
            {
                txtDisplay.Text = ""; // clear 
                if(!Directory.Exists( cboSource.Text ))
                {
                    txtDisplay.Text = "Directory doesn't exist";
                    return;
                }

                string barCode = GetElements( "//HardDisk/@barcode", GetDoneFilename( cboSource.Text ) );
                if(barCode != null)
                {
                    switch(GetProjNameFromMySQL( barCode ))
                    {
                        case "JPMC-Offlinebo-legalhold": // Case A: Check isLegalHold from wamu_dlh_inventory_drive table
                            if(IsLegalHoldFromMySQL( barCode ))
                                txtDisplay.Text = barCode + " is a Legal Hold Drive.";
                            else
                                txtDisplay.Text = barCode + " is NOT a Legal Hold Drive.";
                            break;
                        default:
                            // TO DO: other cases i.e. B and C
                            if(IsLegalHoldFromMySQL( barCode ))
                                txtDisplay.Text = barCode + " is a Legal Hold Drive.";
                            else
                                txtDisplay.Text = barCode + " is NOT a Legal Hold Drive.";
                            break;
                    }//end of switch
                }
                else
                {
                    txtDisplay.Text = "Barcode == null";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message, "btnLegalHold_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }
        }//end of btnLegalHold_Click

        private string GetProjNameFromMySQL( string barCode )
        {
            string rv = null;
            // TO DO: Modularize it and remove all the hard code value, and validate user input            
            string host = "127.0.0.1";
            //string database = "tape";
            //string user = "root";
            //string password = "";
            string database = txtDatabase.Text;
            string user = txtUserID.Text;
            string password = txtPassword.Text;
            string strSQL = "SELECT ProjectName FROM tapeinventorytable where barcode='" + barCode + "'";

            string strProvider = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;

            try
            {
                MySqlConnection mysqlCon = new MySqlConnection( strProvider );
                mysqlCon.Open();

                if(mysqlCon.State.ToString() == "Open")
                {
                    MySqlCommand mysqlCmd = new MySqlCommand( strSQL, mysqlCon );
                    MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();

                    //Expect one result and get the first one
                    if(mysqlReader.Read())
                        rv = mysqlReader.GetString( 0 );
                    
                }//end of if

                mysqlCon.Close();
            }//end of try
            catch(Exception er)
            {
                MessageBox.Show( er.Message, "GetProjNameFromMySQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }

            return (rv);
        }//end of GetProjNameFromMySQL

        /// <summary>
        /// Check is the drive consider as legal hold drive based on the physical HD barcode.
        /// 1. Query islegalhold from wamu_dlh_inventory_drive table
        /// 2. As long as one entry mark as legal hold, the entire drive will consider legal hold, and reture true.
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        private bool IsLegalHoldFromMySQL( string barCode )
        {
            bool rv = false; // assume default is NOT legal hold

            // TO DO: Modularize it and remove all the hard code value, and validate user input            
            string host = "127.0.0.1";
            //string database = "test";
            //string user = "root";
            //string password = "";
            string database = txtDatabase.Text;
            string user = txtUserID.Text;
            string password = txtPassword.Text;
            string strSQL = "SELECT islegalhold FROM test.wamu_dlh_inventory_drive where barcode='" + barCode + "'";

            string strProvider = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;

            try
            {
                MySqlConnection mysqlCon = new MySqlConnection( strProvider );
                mysqlCon.Open();

                if(mysqlCon.State.ToString() == "Open")
                {
                    MySqlCommand mysqlCmd = new MySqlCommand( strSQL, mysqlCon );
                    MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();

                    while(mysqlReader.Read())
                    {
                        //Console.WriteLine(mysqlReader.GetInt32(0) + "\t" + mysqlReader.GetString(1) + "\t" + mysqlReader.GetString(2));
                        if(mysqlReader.GetString( 0 ) == "1")
                        {
                            rv = true;
                            break;
                        }
                    }
                }//end of if

                mysqlCon.Close();
            }//end of try
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message, "IsLegalHoldFromMySQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }
            return (rv);
        }// end of IsLegalHoldFromMySQL

        /// <summary>
        /// Get the online marimba count from MySQL DB.
        /// </summary>
        /// <param name="parentInventoryId">string</param>
        /// <returns></returns>
        public decimal GetOnlineMarimbaCountFromMySQL(int i)
        {
            decimal rv = 0;
            string host = "127.0.0.1";
            string database = txtDatabase.Text;
            string user = txtUserID.Text;
            string password = txtPassword.Text;


            string strSQL = "SELECT sum(marimbaFileCount) FROM wamu_dlh_online_inventory where filepath like '%\\\\\\\\D" + i.ToString( CultureInfo.CurrentCulture ) + "\\\\\\\\%'";
            string strProvider = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;

            try
            {
                MySqlConnection mysqlCon = new MySqlConnection( strProvider );
                mysqlCon.Open();

                if(mysqlCon.State.ToString() == "Open")
                {
                    MySqlCommand mysqlCmd = new MySqlCommand( strSQL, mysqlCon );
                    MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();

                    //Expect one result and get the first one
                    if(mysqlReader.Read())
                        rv = mysqlReader.GetDecimal( 0 );//.ToString();

                }//end of if

                mysqlCon.Close();
            }//end of try
            catch(Exception er)
            {
                MessageBox.Show( er.Message, "GetOnlineMarimbaCountFromMySQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }

            return (rv);

        }//end of GetOnlineMarimbaCountFromMySQL

        /// <summary>
        /// Get the online nsrl count from MySQL DB.
        /// </summary>
        /// <param name="parentInventoryId">string</param>
        /// <returns></returns>
        public decimal GetOnlineNsrlCountFromMySQL(int i)
        {
            decimal rv = 0;
            string host = "127.0.0.1";
            string database = txtDatabase.Text;
            string user = txtUserID.Text;
            string password = txtPassword.Text;


            string strSQL = "SELECT sum(nsrlFileCount) FROM wamu_dlh_online_inventory where filepath like '%\\\\\\\\D" + i.ToString( CultureInfo.CurrentCulture ) + "\\\\\\\\%'";
            string strProvider = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;

            try
            {
                MySqlConnection mysqlCon = new MySqlConnection( strProvider );
                mysqlCon.Open();

                if(mysqlCon.State.ToString() == "Open")
                {
                    MySqlCommand mysqlCmd = new MySqlCommand( strSQL, mysqlCon );
                    MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();

                    //Expect one result and get the first one
                    if(mysqlReader.Read())
                        rv = mysqlReader.GetDecimal( 0 );//.ToString();

                }//end of if

                mysqlCon.Close();
            }//end of try
            catch(Exception er)
            {
                MessageBox.Show( er.Message, "GetOnlineNsrlCountFromMySQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }

            return (rv);

        }//end of GetOnlineNsrlCountFromMySQL

        public decimal GetOnlinePSTCountFromMySQL( int i )
        {
            decimal rv = 0;

            //string barCode = GetElements( "//HardDisk/@barcode", GetDoneFilename( cboSource.Text ) );
            string host = "127.0.0.1";
            string database = txtDatabase.Text;
            string user = txtUserID.Text;
            string password = txtPassword.Text;


            string strSQL = "SELECT sum(pstfilecount) FROM wamu_dlh_online_inventory where filepath like '%\\\\\\\\D" + i.ToString( CultureInfo.CurrentCulture ) + "\\\\\\\\%'";
            string strProvider = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;

            try
            {
                MySqlConnection mysqlCon = new MySqlConnection( strProvider );
                mysqlCon.Open();

                if(mysqlCon.State.ToString() == "Open")
                {
                    MySqlCommand mysqlCmd = new MySqlCommand( strSQL, mysqlCon );
                    MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();

                    //Expect one result and get the first one
                    if(mysqlReader.Read())
                        rv = mysqlReader.GetDecimal( 0 );

                    // Save for reference - read multiple entries
                    //while(mysqlReader.Read())
                    //{
                    //    //    //Console.WriteLine(mysqlReader.GetInt32(0) + "\t" + mysqlReader.GetString(1) + "\t" + mysqlReader.GetString(2));
                    //    Debug.WriteLine( mysqlReader.GetDecimal( 0 ) );
                    //    rv = mysqlReader.GetDecimal( 0 ).ToString();
                    //}
                }//end of if

                mysqlCon.Close();
            }//end of try
            catch(Exception er)
            {
                MessageBox.Show( er.Message, "GetOnlinePSTCountFromMySQL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly );
            }

            return (rv);
        }//end of GetonlinePSTCountFromMySQL
    }
}
