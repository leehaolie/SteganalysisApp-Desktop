using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class ResultValues
    {
        public string test;
        public bool enableConreteMethodsCheck;
        public bool enableWordMapping;
        public bool enableColorQuantization;
        public bool enableUnicodes;
        public int countPotetntialScaleSizes;
        public int openSpacesWordsTotal;
        public int openSpacesWordsPotential;
        public int openSpacesSentencesTotal;
        public int openSpacesSentencesPotential;
        public int unicodeNumberSymbols;
        public Dictionary<string, int> unicodeDirectoryMap;
        public Dictionary<string, int> invisibleCharactersThatTakesNoSpaceHexMap;
        public Dictionary<string, int> invisibleCharactersColorMap;
        public int fontTypeTotal;
        public int fontTypePotential;
        public Dictionary<string, int> fontTypeDirectoryCount;
        public int invisibleCharactersTotal;
        public int invisibleCharactersPotential;
        public int colorQuantizationTotal;
        public int colorQuantizationLight;
        public int colorQuantizationDark;
        public double[] colorQuantizationLightLevels;
        public double[] colorQuantizationDarkLevels;
        public int wordMappingOption1Total;
        public int wordMappingOption1Potential;
        public int wordMappingOption2Total;
        public int wordMappingOption2Potential;
        public int codedParagraphBorder;
        public Dictionary<string, int> generalParagraphLeftBorderMap;
        //public Dictionary<string, int> generalParagraphLeftBorderColorMap;
        //public Dictionary<string, int> generalParagrahpLeftBorderStyleMap;
        public Dictionary<string, int> generalParagraphRightBorderMap;        
        //public Dictionary<string, int> generalParagraphRightBorderColorMap;
        //public Dictionary<string, int> generalParagraphRightBorderStyleMap;
        public int codedSentenceBorder;        
        public Dictionary<string, int> generalSentenceLeftBorderMap;
        public Dictionary<string, int> generalSentenceRightBorderMap;
        //public Dictionary<string, int> generalSentenceLeftBorderColorMap;
        //public Dictionary<string, int> generalSentenceLeftBorderStyleMap;
        public int codedScaling;
        public Dictionary<string, int> generalScalingMap;
        public int codedUnderline;
        public Dictionary<string, int> generalUnderlineMap;
        //public Dictionary<string, int> generalUnderlineColorMap;
        //public Dictionary<string, int> generalUnderlineStyleMap;
        public int codedWhiteSpaces;
    }
}