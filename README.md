# FasterLinq
The aim of this project is to create identical in the functionality Linq to Object extensions, but rather than relying on IEnumerable interface the implementation is done for each collection type, such as arrays, List<T>. 

Doing so results in a performance improvement, for example .Count() on an array simply returns the value of the Length field. The standard extension methods provided by .NET Framework do actually check whether the IEnumerable is a collection in the case of .Count(), however due to the fact that this has to be resolved during runtime hinders the performance. 

In addition the extra code to check if IEnumerable is actually a collection underneath results in bigger methods, thus decreasing chances of the methods being inlined by the JIT.

In other extension methods certain benefits could be achieved by using "for" rather than "foreach" which proves to be marginally faster.
Having extension methods for each specific collection type saves on the performance drawback of having a virtual call, which is the case with IList and ICollection interfaces.
