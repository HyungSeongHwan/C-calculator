using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public enum EType
        {
            eNone = 0,
            eEqual = 1,
            ePlus,
            eMinus,
            eMultiply,
            eDivide,

            eNax = eDivide,
        }

        public EType m_Type = EType.eNone;
        public float m_Result = 0.0f;

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            m_Type = EType.eMultiply;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            m_Type = EType.eMinus;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            m_Type = EType.eDivide;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            m_Type = EType.ePlus;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (m_Type == EType.eNone)
                return;

            float fA = float.Parse(tbInput1.Text);
            float fB = float.Parse(tbInput2.Text);

            m_Result = CalculateValue(m_Type, fA, fB);
            txtResult.Text = string.Format("{0:F}", m_Result);
        }

        private float CalculateValue(EType type, float fA, float fB)
        {
            float fRes = 0;

            switch (type)
            {
                case EType.ePlus:
                    fRes = fA + fB;
                    break;
                case EType.eMinus:
                    fRes = fA - fB;
                    break;
                case EType.eMultiply:
                    fRes = fA * fB;
                    break;
                case EType.eDivide:
                    fRes = fA / fB;
                    break;
            }

            m_Type = EType.eNone;

            return fRes;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            m_Result = 0.0f;
            txtResult.Text = "0";
            tbInput1.Text = "";
            tbInput2.Text = "";
            m_Type = EType.eNone;
        }

        private void txtResult_Click(object sender, EventArgs e)
        {

        }
    }
}
