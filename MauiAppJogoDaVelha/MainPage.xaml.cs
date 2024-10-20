using Microsoft.Maui.Graphics.Text;
using System.Xml;

namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        //Declaração de váriaveis
        string vez = "X";
        Button[,] botoes;



        public MainPage()
        {
            InitializeComponent();

            //Atribuindo os x:Name dos botões da MainPage para um vetor bidimensional
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



            //Caso o botão seja de reset, chamará o método Zerar para reiniciar o jogo e encerrará o evento
            if (btn.Text == "Reset")
            {
                Zerar();
                return;
            }

            //Desativa o botão
            btn.IsEnabled = false;

            //Mudará o texto do botão para o da string vez. Poderá ser "X" ou "O".
            btn.Text = vez;

            //Muda a Fonte para Negrito.
            btn.FontAttributes = FontAttributes.Bold;

            //Caso vez seja "X", mudará a fonte para cor vermelha e seu valor para "O".
            if (vez == "X")
            {
                btn.TextColor = Color.FromArgb("#FF6B63");
                vez = "O";
            } else
            //Caso vez seja "O", mudará a fonte para cor azul e seu valor para "X".
            {
                btn.TextColor = Color.FromArgb("#4A7FF9");
                vez = "X";
            }


            //Caso o método VerificarVitoria com parâmetro "X" retorne um valor verdadeiro, o método MostraResultado vai receber uma string "O [X] ganhou!".
            if (VerificarVitoria("X")) {
                MostrarResultado("O [X] ganhou!");
            }

            //Caso o método VerificarVitoria com parâmetro "O" retorne um valor verdadeiro, o método MostraResultado vai receber uma string "O [O] ganhou!".
            if (VerificarVitoria("O"))
            {
                MostrarResultado("O [O] ganhou!");
            }

            //Caso o método VerificarVelha retorne um valor verdadeiro, o método MostraResultado vai receber uma string "Deu velha".
            if (VerificarVelha())
            {
                MostrarResultado("Deu velha");
            }


        }

        //Método que retorna valor boolean com parâmetro sendo a string jogador que pode ser tanto "X" como "O".
        bool VerificarVitoria (string jogador)
        {
            return (

                //Comparações para ver se o texto dos botões é o mesmo para linhas, colunas e diagonais.
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

        //Método que retorna valor boolean sem parâmetro para verificar se houve Velha.
        bool VerificarVelha()
        {
            //Estrutura de repetição que verificará todos os valores da Matriz botoes.
            foreach (var btn in botoes)
            {
                //Verifica se o botão está ativado ou desativado
                if (btn.IsEnabled) return false;
            }
            //Caso todos os botões retornem o valor false, o método retorna o valor true.
            return true;
        }

        //Método que receberá uma string mensagem e reiniciará o jogo.
        void MostrarResultado(string mensagem)
        {
            //Exibirá a mensagem da string.
            DisplayAlert("Resultado", mensagem, "Ok");
            Zerar();
        }

        //Método para reiniciar o jogo e altera o valor de vez para "X".
        void Zerar()
        {
            vez = "X";
            //Estrutura de repetição que apaga os textos e habilita todos os botões.
            foreach (var btn in botoes)
            {
                btn.Text = "";
                btn.IsEnabled = true;
            }
        }

    }

}