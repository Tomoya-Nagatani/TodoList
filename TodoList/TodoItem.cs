namespace TodoList
{
    class TodoItem
    {
        /* getter: XAMLの {Binding} から値を取得するために必要。
           例: Binding Title の場合、WPFがTitleプロパティのgetterを呼び出してUIに表示。

           setter: 特に IsCompleted のように、UIからの変更（チェックボックスON/OFF）を
           モデル側へ反映させるには setter が必要。双方向バインディングのため。
        */

        /* よくある質問
        Q1. getter だけだとどうなる？
        → UIに表示されるが、ユーザーが変更してもモデルには反映されない（一方向）。

        Q2. setter だけだとどうなる？
        → 初期表示で値が取得できず、バインディングエラーまたは空欄になる。
        */
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
