# WpfWaitView
Shows animated wait window from the parallel thread (asynchronously) with short text message below.

Показывает анимированное окно ожидания из параллельного потока (асинхронно) с краткой текстовой информацией снизу.

Example of use (Пример использования):

WaitViewInstance.Instance.ShowAsync("Простой заголовок, показывающий прогресс выполнения задачи.", this, HealthyManSoftware.WpfWaitView.Models.Enums.WaitStyle.Style_1, Color.Red, Color.Orange);
Thread.Sleep(5000);
WaitViewInstance.Instance.CloseAsync();

WaitViewInstance.Instance.ShowAsync("xyz", HealthyManSoftware.WpfWaitView.Models.Enums.WaitStyle.Style_2);
WaitViewInstance.Instance.SetColors(Color.Red, Color.Orange);
Thread.Sleep(5000);
WaitViewInstance.Instance.SetTitle("xyz ...");
WaitViewInstance.Instance.SetColors(Color.Blue, Color.Aquamarine);
Thread.Sleep(5000);
WaitViewInstance.Instance.CloseAsync();

WaitViewInstance.Instance.ShowAsync(null, this, HealthyManSoftware.WpfWaitView.Models.Enums.WaitStyle.Style_3);
WaitViewInstance.Instance.SetColors(Color.Red, Color.Orange);
Thread.Sleep(5000);
WaitViewInstance.Instance.CloseAsync();
