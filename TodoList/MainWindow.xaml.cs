using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace TodoList
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // TodoItemオブジェクトをリストとして持ち、UIに変更を通知する必要があるため、
        // 通常の List<T> ではなく ObservableCollection<T> を使用している。
        // ※ ObservableCollection はコレクションの追加・削除時にUIへ通知できる
        private ObservableCollection<TodoItem> todoItems = new ObservableCollection<TodoItem>();

        public MainWindow()
        {
            InitializeComponent();
            // ItemsSource: DataGridコントロールにデータを表示させるためのプロパティ
            // 今回は TodoItem のリストをバインドし、各項目（Title/IsCompleted）を表示
            TodoDataGrid.ItemsSource = todoItems;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var title = InputTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(title)){
                todoItems.Add(new TodoItem
                {
                    Title = title,
                    IsCompleted = false,
                });
                InputTextBox.Clear();
            }
        }
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddButton_Click(sender, e);
            }
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            // IsCompleted == trueの項目を抽出 (削除用に一時リストを作成)
            var completedItems = todoItems.Where(item  => item.IsCompleted).ToList();

            // 完了項目を一つずつ変数todoItemで受け取ってループ処理
            foreach (var todoItem in completedItems)
            {
                todoItems.Remove(todoItem);
            }

        }
    }
}
