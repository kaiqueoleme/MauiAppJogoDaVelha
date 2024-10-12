using System.Xml;

/*
namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.IsEnabled = false;


            if (btn.Text == "Reset")
            {
                Zerar();
            }
            else
                if (vez == "X")
            {
                btn.Text = "X";
                vez = "O";
            }
            else
            {
                btn.Text = "O";
                vez = "X";
            }

            //Verificação se X ganhou
            if ((btn10.Text == "X" && btn11.Text == "X" && btn12.Text == "X") ||
                (btn20.Text == "X" && btn21.Text == "X" && btn22.Text == "X") ||
                (btn30.Text == "X" && btn31.Text == "X" && btn32.Text == "X") ||
                (btn10.Text == "X" && btn20.Text == "X" && btn30.Text == "X") ||
                (btn11.Text == "X" && btn21.Text == "X" && btn31.Text == "X") ||
                (btn12.Text == "X" && btn22.Text == "X" && btn32.Text == "X") ||
                (btn10.Text == "X" && btn21.Text == "X" && btn32.Text == "X") ||
                (btn12.Text == "X" && btn21.Text == "X" && btn30.Text == "X")) 
            {
                DisplayAlert("Parabéns!", "O [X] Ganhou!", "Ok");
                Zerar();
            }

            //Verificação se O ganhou
            if ((btn10.Text == "O" && btn11.Text == "O" && btn12.Text == "O") ||
                (btn20.Text == "O" && btn21.Text == "O" && btn22.Text == "O") ||
                (btn30.Text == "O" && btn31.Text == "O" && btn32.Text == "O") ||
                (btn10.Text == "O" && btn20.Text == "O" && btn30.Text == "O") ||
                (btn11.Text == "O" && btn21.Text == "O" && btn31.Text == "O") ||
                (btn12.Text == "O" && btn22.Text == "O" && btn32.Text == "O") ||
                (btn10.Text == "O" && btn21.Text == "O" && btn32.Text == "O") ||
                (btn12.Text == "O" && btn21.Text == "O" && btn30.Text == "O"))
            {
                DisplayAlert("Parabéns!", "O [O] Ganhou!", "Ok");
                Zerar();
            }

            //Verificação se der Velha

            if (btn10.IsEnabled == false && btn11.IsEnabled == false && btn12.IsEnabled == false &&
                btn20.IsEnabled == false && btn21.IsEnabled == false && btn22.IsEnabled == false &&
                btn30.IsEnabled == false && btn31.IsEnabled == false && btn32.IsEnabled == false)
            {
                DisplayAlert("Que pena!", "Deu Velha", "Ok");
                Zerar();
            }
        }

        void Zerar()
        {
            vez = "X";

            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";

            btn20.Text = "";
            btn21.Text = "";
            btn22.Text = "";

            btn30.Text = "";
            btn31.Text = "";
            btn32.Text = "";

            btn10.IsEnabled = true;
            btn11.IsEnabled = true;
            btn12.IsEnabled = true;

            btn20.IsEnabled = true;
            btn21.IsEnabled = true;
            btn22.IsEnabled = true;

            btn30.IsEnabled = true;
            btn31.IsEnabled = true;
            btn32.IsEnabled = true;

            btnReset.IsEnabled = true;
        }
    }

}
*/

namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        Button[,] botoes;

        public MainPage()
        {
            InitializeComponent();
            botoes = new Button[,]
            {
                {btn10, btn11, btn12 },
                {btn20, btn21, btn22 },
                {btn30, btn31, btn32 },
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "Reset")
            {
                Zerar();
                return;
            }

            btn.IsEnabled = false;
            btn.Text = vez;

            vez = (vez == "X") ? "O" : "X";

            if (VerificarVitoria("X")) {
                MostrarResultado("O [X] ganhou!");
            }

            if (VerificarVitoria("O"))
            {
                MostrarResultado("O [O] ganhou!");
            }

            if (VerificarVelha())
            {
                MostrarResultado("Deu velha");
            }


        }

        bool VerificarVitoria (string jogador)
        {
            return (
                (botoes[0, 0].Text == jogador && botoes[0, 1].Text == jogador && botoes[0, 2].Text == jogador) || // Linha 1
                (botoes[1, 0].Text == jogador && botoes[1, 1].Text == jogador && botoes[1, 2].Text == jogador) || // Linha 2
                (botoes[2, 0].Text == jogador && botoes[2, 1].Text == jogador && botoes[2, 2].Text == jogador) || // Linha 3
                (botoes[0, 0].Text == jogador && botoes[1, 0].Text == jogador && botoes[2, 0].Text == jogador) || // Coluna 1
                (botoes[0, 1].Text == jogador && botoes[1, 1].Text == jogador && botoes[2, 1].Text == jogador) || // Coluna 2
                (botoes[0, 2].Text == jogador && botoes[1, 2].Text == jogador && botoes[2, 2].Text == jogador) || // Coluna 3
                (botoes[0, 0].Text == jogador && botoes[1, 1].Text == jogador && botoes[2, 2].Text == jogador) || // Diagonal principal
                (botoes[0, 2].Text == jogador && botoes[1, 1].Text == jogador && botoes[2, 0].Text == jogador)    // Diagonal secundária
                );
        }

        bool VerificarVelha()
        {
            foreach (var btn in botoes)
            {
                if (btn.IsEnabled) return false;
            }
            return true;
        }

        void MostrarResultado(string mensagem)
        {
            DisplayAlert("Resultado", mensagem, "Ok");
            Zerar();
        }

        void Zerar()
        {
            vez = "X";
            foreach (var btn in botoes)
            {
                btn.Text = "";
                btn.IsEnabled = true;
            }
        }

    }

}