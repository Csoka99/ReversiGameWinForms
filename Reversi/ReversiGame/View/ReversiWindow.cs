using ReversiGame.Model;
using ReversiGame.Persistence;
using System.Data.Common;
using System.Resources;
using System.IO;
using System.Reflection;
using System.Windows.Forms.PropertyGridInternal;
using static System.Windows.Forms.AxHost;
using ReversiGame.EventArguments;
using Timer = System.Windows.Forms.Timer;
using System.IO.Packaging;

namespace ReversiGame.View
{
    public partial class ReversiWindow : Form
    {

        ReversiModel model;
        private Timer _timer;
        public ReversiWindow()
        {
            InitializeComponent();

            tenStripMenu.Click += (sender, args) => model.StartNewGame(10);
            twentyStripMenu.Click += (sender, args) => model.StartNewGame(20);
            thirtyStripMenu.Click += (sender, args) => model.StartNewGame(30);

            model = new ReversiModel(new DataAccess());
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += onTimerTicked;

            model.GameStarted += onGameStarted;
            model.FieldChanged += onFieldChanged;
            model.GameOver += onGameOver;
            model.GamePassed += onGamePassed;

            model.StartNewGame(8);
        }

        private void onTimerTicked(object? sender, EventArgs e)
        {
            model.TimerTicked();
            blackTime.Text = $"Black time: {model.IntToTime(model.BlackTime)}";
            whiteTime.Text = $"White time: {model.IntToTime(model.WhiteTime)}";
        }

        private void onGamePassed(object? sender, GamePassedEventArgs e)
        {
            MessageBox.Show(
                    $"{e.Pass} had to pass!",
                    "Passed!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
        }

        private void onGameOver(object? sender, EventArguments.GameOverEventArgs e)
        {
            _timer.Stop();
            MessageBox.Show(
                    $"Game over! The winner: {e.Winner}",
                    "Game over",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
        }

        private void onGridButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var position = buttonTableLayout.GetPositionFromControl(button);
            model.FieldClicked(position.Row, position.Column);
        }

        private void onFieldChanged(object? sender, EventArguments.FieldChangedEventArgs e)
        {
            var button = buttonTableLayout.GetControlFromPosition(e.Column, e.Row) as Button;
            setButtonColour(button, e.NewState);
            setPoints();
        }

        private void setPoints()
        {
            blackPointLabel.Text = $"Black : {model.BlackNum}";
            whitePointLabel.Text = $"White : {model.WhiteNum}";
        }

        private void onGameStarted(object? sender, EventArguments.GameStartedEventArgs e)
        {
            var size = e.BoardSize;
            var board = e.Board;

            _timer.Start();

            buttonTableLayout.RowCount = size + 1;
            buttonTableLayout.ColumnCount = size + 1;
            buttonTableLayout.Controls.Clear();

            buttonTableLayout.RowStyles.Clear();
            buttonTableLayout.ColumnStyles.Clear();

            for (int i = 0; i < size; i++)
            {
                buttonTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 1 / Convert.ToSingle(size)));
                buttonTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1 / Convert.ToSingle(size)));

            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var button = new Button();
                    button.FlatStyle = FlatStyle.Flat;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.AutoSize = true;
                    button.Dock = DockStyle.Fill;
                    button.Click += onGridButtonClicked;
                    setButtonColour(button, board[i, j]);
                    buttonTableLayout.Controls.Add(button, j, i);
                }
            }
            setPoints();
        }

        private void setButtonColour(Button button, FieldStates fieldStates)
        {
            switch (fieldStates)
            {
                case FieldStates.Empty:
                    button.BackColor = Color.Green;
                    button.Enabled = false;
                    button.BackgroundImage = null;
                    break;
                case FieldStates.White:
                    button.BackColor = Color.Green;
                    button.Enabled = false;
                    button.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory()+ "\\Resources\\white.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case FieldStates.Black:
                    button.BackColor = Color.Green;
                    button.Enabled = false;
                    button.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory()+"\\Resources\\black.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case FieldStates.ValidMove:
                    button.BackColor= Color.Red;
                    button.Enabled = true;
                    button.BackgroundImage = null;
                    break;
            }
        }

        private void onPauseMenuItemClicked(object sender, EventArgs e)
        {
            _timer.Stop();
            MessageBox.Show(
                    $"The game has stopped! Press OK to continue!",
                    "Pause!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            _timer.Start();
        }

        private void onExitMenuItemClicked(object sender, EventArgs e)
        {
            Close();
        }

        private async void onSaveMenuItemClicked(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();

            var result = saveFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                await model.SaveGame(path);
            }
        }

        private async void onLoadGameMenuItemClicked(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                await model.LoadGame(path);
            }
        }
    }
}