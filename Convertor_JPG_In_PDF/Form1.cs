
using System;
using System.IO;
using System.Linq;
using System.Collections;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.ComponentModel;
using System.Diagnostics;

namespace Convertor_JPG_In_PDF
{
    public partial class Form1 : Form
    {

        public int CountSussess { get { return countSussess; } set
            { 
                countSussess = value; 
                SetIndicators();
            } }
        
        int AllCount = 0;

        string Pathnewir { get; set; }

        BindingList<Log> Logs { get; set; }

        int CountToListBinding = 0;

        bool working = true;

        string PathDirectoryInTextBox
        {
            get { return pathDirectoryOutTextBox; }
            set
            {
                pathDirectoryOutTextBox = value;
            }
        }


        string pathDirectoryOutTextBox = string.Empty;
        int countSussess = 0;

        const string download = "Загружено";

        public Form1()
        {
            InitializeComponent();
            StartConvert.Enabled = false;
            listLogs.Enabled = false;   
            IndicatorsBar.Minimum = 0;
            Logs = new BindingList<Log>();
            Logs.ListChanged += Logs_ListChanged;
            
        }

        private void Logs_ListChanged(object? sender, ListChangedEventArgs e)
        {
            var list = sender as BindingList<Log>;

            if (list.Count != CountToListBinding)
            {
                CountToListBinding = list.Count;
                if (CountToListBinding != 0 && !listLogs.Enabled)
                {
                    listLogs.Enabled = true;
                }else if(CountToListBinding == 0)
                {
                    listLogs.Enabled=false;
                }

            }

        }

        public void SetIndicators()
        {
            BeginInvoke(() => {
                SetLabelDownload();
                IndicatorsBar.Value = countSussess;
            });
            
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CountToListBinding != 0)
                {
                  listLogs.Items.Clear();
                }
                List<string> allpathfiles = GetAllFilesPath(PathDirectoryInTextBox);
                if (allpathfiles.Count != 0)
                {
                    Pathnewir = PathDirectoryInTextBox + "\\PDF";
                    AllCount = IndicatorsBar.Maximum = allpathfiles.Count;

                    Directory.CreateDirectory(Pathnewir);
                    SetLabelDownload();
                 await toListConvrteAsync(allpathfiles);
                    


                
                    CountSussess = 0;
                    StartConvert.Enabled = false;
                    PathDirectory.Text = String.Empty;
                    AllCount = 0;
                    Pathnewir = String.Empty;
                    working = false;


                }
                else
                {
                    MessageBox.Show("Не найдено подходящего файла. Проверте правильость написания пути к папке.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PathDirectory.Focus();
            }

        }

        void SetLabelDownload()
        {
            CountTextLabel.Text = $"{download} {countSussess} из {AllCount}";
        }

        /// <summary>
        /// Возвращает все пути файлов которые были найдены в папке
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> GetAllFilesPath(string path)
        {
            var result = new List<string>();

           
                
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                List<FileInfo> files = directoryInfo.GetFiles().ToList();

                foreach (FileInfo file in files)
                {
                    if (file.Extension.ToUpper() == ".jpg".ToUpper() ||
                       file.Extension.ToUpper() == ".JPG".ToUpper() ||
                       file.Extension.ToUpper() == ".Jpg".ToUpper())
                        result.Add(file.FullName);
                }

            }
            catch (Exception w)
            {
                throw new Exception("Не верный формат строки адреса папки.");

            }
            

            return result;
        }
            

        async Task toListConvrteAsync(List<string> paths)
        {
            await Task.Run(() => {toListConvrte(paths); });
            var result = MessageBox.Show("Операция по конвертированию завершена!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool toListConvrte(List<string> pathsJpg)
        {
            try
            {

                foreach (string path in pathsJpg)
                {
                    ImagesToPdf(path);
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;   
            }
        }

        public async void ImageToPdfAsycn(string pathJpg)
        {
            await Task.Run(() => { ImagesToPdf(pathJpg);  });
        }

        public void ImagesToPdf(string imagepaths)
        {
            iTextSharp.text.Rectangle pageSize = null;
            Log log = new Log();
            var FileForBitmap = new FileInfo(imagepaths);
            
            using (var srcImage = new Bitmap(FileForBitmap.FullName))
            {
                pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
            }

            using (var ms = new MemoryStream())
            {
                var document = new Document(pageSize, 0, 0, 0, 0);
                PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(imagepaths.ToString());
                document.Add(image);
                document.Close();
                string pdfName = Pathnewir + "\\" + FileForBitmap.Name;
                File.WriteAllBytes(pdfName + ".pdf", ms.ToArray());
                log = new Log{ NameFile = FileForBitmap.Name, 
                NewPath = pdfName,
                Message = "Успешно",
                Action = "Конвертация JPG в PDF"};
                
            }
            CountSussess++;
            

            BeginInvoke(() => {
                Logs.Add(log);
                listLogs.Items.Add(log.ToString());

            });

        }

        private void LogsLabel_Click(object sender, EventArgs e)
        {

        }

        private void PathDirectory_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void PathDirectory_TextChanged(object sender, EventArgs e)
        {
            if (chekinputtext(PathDirectory))
            {
                StartConvert.Enabled = true;
                TextBox textBox = sender as TextBox;
                PathDirectoryInTextBox = textBox.Text;
            }
            else
            {
                StartConvert.Enabled=false;
            }
        }

        bool chekinputtext(TextBox text)
        {
            if (text!=null && text.Text!= null && text.Text!= string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        private void PathDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && StartConvert.Enabled)
            {
                button1_Click(StartConvert, null);
            }
        }
    }
}
