using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.DTO;
using static IndianStateCensusAnalyzer.CensusAnalyser;

namespace CensusAnalyzerTest
{
    public class Tests
    {

        //CensusAnalyser.CensusAnalyser censusAnalyser;

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"E:\RFP 215\IndianStateCensusAnalyzer\IndianStateCsensusAnalyser\IndianStateCensusAnalyzer\CsvFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"E:\RFP 215\IndianStateCensusAnalyzer\IndianStateCsensusAnalyser\IndianStateCensusAnalyzer\CsvFiles\WrongIndiaStateCode.csv";
        static string delimiterIndianCensusFilePath = @"E:\RFP 215\IndianStateCensusAnalyzer\IndianStateCsensusAnalyser\IndianStateCensusAnalyzer\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"E:\RFP 215\IndianStateCensusAnalyzer\IndianStateCsensusAnalyser\IndianStateCensusAnalyzer\CsvFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"E:\RFP 215\IndianStateCensusAnalyzer\IndianStateCsensusAnalyser\IndianStateCensusAnalyzer\CsvFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"E:\RFP 215\IndianStateCensusAnalyzer\IndianStateCsensusAnalyser\IndianStateCensusAnalyzer\CsvFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"E:\RFP 215\IndianStateCensusAnalyzer\IndianStateCsensusAnalyser\IndianStateCensusAnalyzer\CsvFiles\WrongIndiaStateCode.csv";
        static string delimiterIndianStateCodeFilePath = @"E:\RFP 215\IndianStateCensusAnalyzer\CensusAnalyzerTest\CsvFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"E:\RFP 215\IndianStateCensusAnalyzer\IndianStateCsensusAnalyser\IndianStateCensusAnalyzer\CsvFiles\WrongIndiaStateCode.csv";
           
        //US Census FilePath
        static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        static string usCensusFilepath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.csv";
        static string wrongUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USData.csv";
        static string wrongUSCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.txt";
        static string wrongHeaderUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\WrongHeaderUSCensusData.csv";
        static string delimeterUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\DelimiterUSCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

    }

}