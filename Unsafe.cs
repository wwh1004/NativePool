namespace NativePool {
	internal static unsafe class Unsafe {
		public static void* GetTypeHandle<T>() {
			var dummy = default(T);
			var @ref = __makeref(dummy);
			return ((void**)&@ref)[1];
		}

		public static uint GetTypeSize<T>() {
			return ((uint*)GetTypeHandle<T>())[1];
		}

		public static TTo As<TFrom, TTo>(TFrom value) where TFrom : class where TTo : class {
			return ToObject<TTo>(ToPointer(value));
		}

		public static void* ToPointer<T>(T value) where T : class {
			var @ref = __makeref(value);
			return **(void***)&@ref;
		}

		public static T ToObject<T>(void* ptr) where T : class {
			var dummy = default(T);
			var @ref = __makeref(dummy);
			*(void**)&@ref = &ptr;
			return __refvalue(@ref, T);
		}
	}
}
