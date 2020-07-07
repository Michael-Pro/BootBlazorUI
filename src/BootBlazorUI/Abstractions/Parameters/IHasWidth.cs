﻿
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件具备宽度的参数。
    /// </summary>
    public interface IHasWidth : IHasParameter
    {
        /// <summary>
        /// 设置组件的宽度百分比，<c>null</c> 表示不使用宽度百分比。
        /// </summary>
        /// <value>
        /// <see cref="BootBlazorUI.Width"/> 的枚举值或 <c>null</c>。
        /// </value>
        public Width? WidthPercent { get; set; }

        /// <summary>
        /// 设置组件的固定宽度。
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 设置组件的最大宽度。
        /// </summary>
        public string MaxWidth { get; set; }
        /// <summary>
        /// 设置组件的最小宽度。
        /// </summary>
        public string MinWidth { get; set; }
    }
}
