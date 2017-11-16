using System.Drawing;
namespace AppLaMejor.stylemanager
{
    class StyleEntity
    {

        public StyleEntity(Font _mainFont, Font _mainFontSmall, Font _mainFontBig, Font _mainFontFormTitle,
            Font _mainFontBold, Font _mainFontSmallBold, Font _mainFontBigBold, Font _mainFontFormTitleBold,
            Color _backColor, Color _mainColor, Color _textColor, Color _mouseDownBackColor, Color _mouseOverBackColor)
        {
            mainFont = _mainFont;
            mainFontSmall = _mainFontSmall;
            mainFontBig = _mainFontBig;
            mainFormTitle = _mainFontFormTitle;
            mainFontBold = _mainFontBold;
            mainFontSmallBold = _mainFontSmallBold;
            mainFontBigBold = _mainFontBigBold;
            mainFormTitleBold = _mainFontFormTitleBold;
            backColor = _backColor;
            mainColor = _mainColor;
            textColor = _textColor;
            mouseDownBackColor = _mouseDownBackColor;
            mouseOverBackColor = _mouseOverBackColor;
        }

        Font mainFont;

        public Font MainFont
        {
            get { return mainFont; }
            set { mainFont = value; }
        }
        Font mainFontSmall;

        public Font MainFontSmall
        {
            get { return mainFontSmall; }
            set { mainFontSmall = value; }
        }
        Font mainFontBig;

        public Font MainFontBig
        {
            get { return mainFontBig; }
            set { mainFontBig = value; }
        }

        Font mainFormTitle;

        public Font MainFontTitle
        {
            get { return mainFormTitle; }
            set { mainFormTitle = value; }
        }

        Font mainFontBold;

        public Font MainFontBold
        {
            get { return mainFontBold; }
            set { mainFontBold = value; }
        }
        Font mainFontSmallBold;

        public Font MainFontSmallBold
        {
            get { return mainFontSmallBold; }
            set { mainFontSmallBold = value; }
        }
        Font mainFontBigBold;

        public Font MainFontBigBold
        {
            get { return mainFontBigBold; }
            set { mainFontBigBold = value; }
        }

        Font mainFormTitleBold;

        public Font MainFontTitleBold
        {
            get { return mainFormTitle; }
            set { mainFormTitle = value; }
        }

        Color backColor;

        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }
        Color mainColor;

        public Color MainColor
        {
            get { return mainColor; }
            set { mainColor = value; }
        }
        Color textColor;

        public Color TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }
        Color mouseDownBackColor;

        public Color MouseDownBackColor
        {
            get { return mouseDownBackColor; }
            set { mouseDownBackColor = value; }
        }
        Color mouseOverBackColor;

        public Color MouseOverBackColor
        {
            get { return mouseOverBackColor; }
            set { mouseOverBackColor = value; }
        }
        
    }
}