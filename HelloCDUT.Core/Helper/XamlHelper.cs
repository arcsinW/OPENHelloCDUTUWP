using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace HelloCDUT.Core.Helper
{
    public class XamlHelper
    {
        /// <summary>
        /// Find a special type child of a root
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        public static T FindChildOfType<T>(DependencyObject root) where T : class
        {
            //创建一个队列结构来存放可视化树的对象
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(root);
            //循环查找类型
            while (queue.Count > 0)
            {
                DependencyObject current = queue.Dequeue();
                //查找子节点的对象类型
                for (int i = VisualTreeHelper.GetChildrenCount(current) - 1; 0 <= i; i--)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    var typedChild = child as T;
                    if (typedChild != null)
                    {
                        return typedChild;
                    }
                    queue.Enqueue(child);
                }
            }
            return null;
        }
    }
}
