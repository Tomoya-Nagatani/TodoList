using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoList
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // TodoItemオブジェクトをリストとして持ち、UIに通知させるコレクション
        // イメージ: content, isCompletedなどの情報を1行ずつタスクデータとして管理するリスト = これなら通常のListでも可能
        // 今回はTodoアプリなので追加・削除するので変更を通知させる必要があり、適しているのがこのリスト型
        private ObservableCollection<TodoItem> todoItems = new ObservableCollection<TodoItem>();

        public MainWindow()
        {
            InitializeComponent();
            // ItemsSource: DataGridコントロールのプロパティで、DataGridに表示させるデータを設定できる
            // 今回だとTodoItemモデルのオブジェクト
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
            else
            {
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
