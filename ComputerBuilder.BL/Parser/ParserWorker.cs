using System;


namespace ComputerBuilder.BL.Parser
{
    public class ParserWorker<T> where T : class
    {
        FileLoader loader;
        bool isActive;
        public IParser<T> parser;

        #region Свойства
        public event Action<object, T> OnNewData;
        public event Action<object> OnComplete;
        public ParserWorker()
        {
        }
        public ParserWorker(IParser<T> parser, string targetFile)
        {
            this.parser = parser;
            loader = new FileLoader(targetFile);
        }
        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }
        #endregion
        public void Start()
        {
            isActive = true;
            ExportCpu();
        }
        public void Abort()
        {
            OnComplete?.Invoke(this);
            isActive = false;

        }
        private async void ExportCpu()
        {
            if (!isActive)
            {
                return;
            }
            var source = await loader.Load();
            var result = parser.Parse(source);

            OnNewData?.Invoke(this, result);
            OnComplete?.Invoke(this);

            isActive = false;
        }

    }
}
