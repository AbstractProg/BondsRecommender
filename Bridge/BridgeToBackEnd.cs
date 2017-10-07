using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;
using System.Windows.Forms;

namespace Bridge
{
    public class BridgeToBackEnd
    {
        FundsExtractor m_FundsExtractor;
        BondsUpdater m_BondsUpdater;

        public BridgeToBackEnd(FundsExtractor FundsExtractor_, BondsUpdater BondsUpdater_)
        {
            m_FundsExtractor = FundsExtractor_;
            m_BondsUpdater = BondsUpdater_;
        }

        public void ExtractFunds_BRDG()
        {
            m_FundsExtractor.FindFunds();
        }

        public void UpdateBonds_BRDG()
        {
            m_BondsUpdater.UpdateBondsData();
        }
    }
}