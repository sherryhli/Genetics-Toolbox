using System.Net;
using System.IO;
using System.Xml;

namespace HardyWeinberg
{
    /// <summary>
    /// This provider is used to obtain data using Wolfram|Alpha's Instant Calculator API
    /// </summary>
    public class HardyWeinbergProvider
    {
        private readonly string url = "http://www.wolframalpha.com/api/v2/query?";
        private readonly string appId = "RP3Q3E-UEKAV4KLHE";
        // Selects the calculator to use, use Wolfram's Fast Query Recognizer API to verify this
        private readonly string input = "Hardy+Weinberg+law";

        /// <summary>
        /// Gets Hardy-Weinberg XML pod nodes from Wolfram|Alpha
        /// </summary>
        /// <param name="formulaCode">The formula to use, based on type of input</param>
        /// <param name="variableValue">The variable value, either an allele or a genotype frequency</param>
        /// <returns>A list of XML pod nodes</returns>
        public XmlNodeList GetHardyWeinbergResults(int formulaCode, string variableValue)
        {
            string formulaSelect;
            string formulaVariable;

            switch (formulaCode)
            {
                case (int)Formulas.FormulaCodes.HardyWeinbergFormulaGivenHeterozygoteFrequency:
                    formulaSelect = "FSelect_**HardyWeinbergFormulaGivenHeterozygoteFrequency--";
                    formulaVariable = "*F.HardyWeinbergFormulaGivenHeterozygoteFrequency.Aa-_";
                    break;
                case (int)Formulas.FormulaCodes.HardyWeinbergFormulaGivenRecessiveHomozygoteFrequency:
                    formulaSelect = "FSelect_**HardyWeinbergFormulaGivenRecessiveHomozygoteFrequency--";
                    formulaVariable = "*F.HardyWeinbergFormulaGivenRecessiveHomozygoteFrequency.aa-_";
                    break;
                case (int)Formulas.FormulaCodes.HardyWeinbergFormulaGivenDominantHomozygoteFrequency:
                    formulaSelect = "FSelect_**HardyWeinbergFormulaGivenDominantHomozygoteFrequency--";
                    formulaVariable = "*F.HardyWeinbergFormulaGivenDominantHomozygoteFrequency.AA-_";
                    break;
                case (int)Formulas.FormulaCodes.HardyWeinbergFormulaGivenRecessiveAlleleFrequency:
                    formulaSelect = "FSelect_**HardyWeinbergFormulaGivenRecessiveAlleleFrequency--";
                    formulaVariable = "*F.HardyWeinbergFormulaGivenRecessiveAlleleFrequency.a-_";
                    break;
                default:
                    formulaSelect = "FSelect_**HardyWeinbergFormulaGivenDominantAlleleFrequency--";
                    formulaVariable = "*F.HardyWeinbergFormulaGivenDominantAlleleFrequency.A-_";
                    break;
            }

            var urlWithFullQuery = url + $"appid={appId}&input={input}&assumption={formulaSelect}&assumption={formulaVariable}{variableValue}";
            var request = WebRequest.Create(urlWithFullQuery);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var reader = new StreamReader(responseStream);
            string responseFromApi = reader.ReadToEnd();
            reader.Close();
            response.Close();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromApi);
            var pods = doc.SelectNodes("*/pod");

            return pods;
        }
    }
}