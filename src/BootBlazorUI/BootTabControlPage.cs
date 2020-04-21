﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 <see cref="BootTabControl"/> 组件的标签页面组件。
    /// </summary>
    public class BootTabControlPage : BootComponentBase
    {
        /// <summary>
        /// 初始化 <see cref="BootTabControlPage"/> 类的新实例。
        /// </summary>
        public BootTabControlPage()
        {
        }

        /// <summary>
        /// 标签控件。
        /// </summary>
        [CascadingParameter]
        internal BootTabControl CascadedTabControl { get; set; }

        /// <summary>
        /// 设置标签页内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置标签页面标题。
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// 设置当标签页被激活时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<BootTabControlPage> OnActived { get; set; }

        /// <summary>
        /// 初始化 <see cref="BootTabControlPage"/> 组件。
        /// </summary>
        protected override void OnInitialized()
        {
            if (CascadedTabControl == null)
            {
                throw new ArgumentNullException(nameof(CascadedTabControl), $"{nameof(BootTabControlPage)} 必须在 {nameof(BootTabControl)} 内部创建");
            }
            base.OnInitialized();
            CascadedTabControl.AddPage(this);
        }

        /// <summary>
        /// 创建选项卡页面的 class 名称。
        /// </summary>
        /// <param name="collection">class 集合。</param>
        protected override void CreateComponentCssClass(ICollection<string> collection)
        {
            collection.Add("tab-pane");

            if (CascadedTabControl.ActivedPage == this)
            {
                collection.Add("active");
            }
        }

        /// <summary>
        /// 构造组件的渲染树。
        /// </summary>
        /// <param name="builder"><see cref="RenderTreeBuilder"/> 实例。</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            base.AddCommonAttributes(builder);
            builder.AddContent(1, ChildContent);
            builder.CloseElement();
        }
    }
}