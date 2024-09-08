#if IL_TEQUILA_UNITASK_SUPPORT
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace IL.Tequila
{
    public static class UniTaskUtility
    {
        public static async UniTask WaitUntilAsync<TState>(TState state, Func<TState, bool> predicate, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
    
            while (!predicate(state))
            {
                await UniTask.Yield(cancellationToken);
            }
        }
    
        public static async UniTask WaitWhileAsync<TState>(TState state, Func<TState, bool> predicate, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
    
            while (predicate(state))
            {
                await UniTask.Yield(cancellationToken);
            }
        }
    }
}
#endif
