using System.Drawing;
namespace AppLaMejor.stylemanager
{
    class StyleManager
    {
        private static StyleManager _instance = null;

        private StyleEntity currentStyle;
      
        public StyleEntity GetCurrentStyle(){
            return currentStyle;
        }

        /* Clase singleton que retorna estilos visuales */
        public static StyleManager Instance()
        {
            if (_instance == null)
                _instance = new StyleManager();
            return _instance;
        }

        private StyleManager()
        {
            this.currentStyle = GetBasicStyle();
        }

        private StyleEntity GetBasicStyle()
        {
            Font mainFontSmall = new Font("Source Sans Pro", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font mainFont = new Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font mainFontBig = new Font("Source Sans Pro", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font mainFontFormTitle = new Font("Source Sans Pro", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Font mainFontSmallBold = new Font("Source Sans Pro", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font mainFontBold = new Font("Source Sans Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font mainFontBigBold = new Font("Source Sans Pro", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Font mainFontFormTitleBold = new Font("Source Sans Pro", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Color backColor = Color.Black;
            Color mainColor = Color.Green;
            Color textColor = Color.White;
            Color mouseDownBackColor = Color.MediumSeaGreen;
            Color mouseOverBackColor = Color.DarkSlateGray;

            return new StyleEntity(mainFont, mainFontSmall, mainFontBig, mainFontFormTitle,
                mainFontBold, mainFontSmallBold, mainFontBigBold, mainFontFormTitleBold,
                backColor, mainColor,
                textColor, mouseDownBackColor, mouseOverBackColor);
        }




    }
}