﻿
namespace HealthyPerson.WpfWaitView.Models.Enums
{
    /// <summary>
    /// Стиль отображения окна ожидания
    /// </summary>
    public enum WaitStyle
    {
        /// <summary>
        /// Стиль 1: Бегунок одноцветный с первым кружочком отдельно указанного цвета, внизу текстовая подсказка о выполнении.
        /// </summary>
        Style_1,

        /// <summary>
        /// Стиль 2: Бегунок двухцветный 50/50, внизу текстовая подсказка о выполнении.
        /// </summary>
        Style_2,

        /// <summary>
        /// Стиль 3: Бегунок одноцветный с первым кружочком отдельно указанного цвета, текстовой подсказки нет.
        /// </summary>
        Style_3,

        /// <summary>
        /// Стиль 4: Бегунок двухцветный 50/50, текстовой подсказки нет.
        /// </summary>
        Style_4
    }

}