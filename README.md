# WpfWaitView
Shows animated wait window from the parallel thread (asynchronously) with short text message below.

Показывает анимированное окно ожидания из параллельного потока (асинхронно) с краткой текстовой информацией снизу.

Example of use (Пример использования):

WpfWaitView.WaitViewInstance.Instance.ShowAsync("Простой заголовок, показывающий прогресс выполнения задачи.", this);
Thread.Sleep(5000);
WpfWaitView.WaitViewInstance.Instance.CloseAsync();

WpfWaitView.WaitViewInstance.Instance.ShowAsync("xyz");
Thread.Sleep(5000);
WpfWaitView.WaitViewInstance.Instance.SetTitle("xyz ...");
WpfWaitView.WaitViewInstance.Instance.SetColors(Color.Blue, Color.Aquamarine);
Thread.Sleep(5000);
WpfWaitView.WaitViewInstance.Instance.CloseAsync();

WpfWaitView.WaitViewInstance.Instance.ShowAsync(null, this);
Thread.Sleep(5000);
WpfWaitView.WaitViewInstance.Instance.CloseAsync();
