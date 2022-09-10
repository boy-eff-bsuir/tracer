using Tracer.Core.Models;

namespace Tracer.Core.Extensions
{
    public static class DtoExtension
    {
        public static MethodInfoResult ToMethodInfoResult(this MethodInfo method)
        {
            return new MethodInfoResult(
                method.Id,
                method.Name,
                method.ClassName,
                method.ExecutionTime
            );
        }

        public static ThreadInfoResult ToThreadInfoResult(this Tree<MethodInfo> tree)
        {
            var node = tree.Root;
            var result = new MethodInfoResult();
            TraverseMethodInfoToResult(node, result);

            return new ThreadInfoResult(
                tree.Id,
                tree.Root.Children.Sum(x => x.Data.ExecutionTime),
                result.Methods
            );
        }

        private static void TraverseMethodInfoToResult(Node<MethodInfo> info, MethodInfoResult result)
        {
            result.Methods = info.Children.Select(
                x => x.Data.ToMethodInfoResult()).ToList().AsReadOnly();

            for (int i = 0; i < info.Children.Count; i++)
            {
                TraverseMethodInfoToResult(info.Children[i], result.Methods[i]);
            }
        }
    }
}