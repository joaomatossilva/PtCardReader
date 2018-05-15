using System;
using pt.portugal.eid;

namespace PtCardReader32
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PTEID_ReaderSet.initSDK();
                var readerSet = PTEID_ReaderSet.instance();
                var reader = readerSet.getReader();

                if (!reader.isCardPresent())
                {
                    Console.WriteLine("No card present");
                }
                else
                {
                    var card = reader.getEIDCard();

                    //flag for checking sod
                    card.doSODCheck(true);

                    var id = card.getID();
                    var name = id.getGivenName();
                    var number = id.getDocumentNumber();

                    Console.WriteLine("{0} - {1}", name, number);
                }
            }
            catch(PTEID_Exception ex)
            {
                Console.WriteLine("PTEID_Exception - {0:X} - {1}", ex.GetError(), ex.Message);
            }
            finally
            {
                PTEID_ReaderSet.releaseSDK();
            }
        }
    }
}
