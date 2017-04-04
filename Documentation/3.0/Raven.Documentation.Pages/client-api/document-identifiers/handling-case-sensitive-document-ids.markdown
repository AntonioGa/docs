# Handling case sensitive document IDs

RavenDB document ids are handled by design in a case insensitive way, therefore using .Load operations over case sensitive ids would fail.

The scenario for this requirement is pretty straightforward.

1. You are not in control of how the Ids are generated.
2. You cannot afford to encounter an stalled index.
3. Your write patterns during the operation puts pressure on the indexing.

The solution for this scenario is to resort to only use .Load operations for all time critical operations [2, 3]. However, when coupled with condition [1] you cannot ensure that there wont be collisions. The trick to handle this case is encode the case sensitive key into a unique representation that can be stored in a case insensitive way.

```csharp
       public class TokenEntity
       {
            public string Token { get; set; }

            public string Secret { get; set; }

            public TokenEntity()
            {
                this.Token = string.Empty;
                this.Secret = string.Empty;
            }
       }
```       

The token is the read id that a .Load operations would use. Therefore what we have to do is override the stored naming.   

In this example we will use a prefix but you can use the typical convention:

```csharp
        public string ToRavenId()
        {
            return IdPrefix + Convert.ToBase64String(CultureInfo.InvariantCulture.CompareInfo.GetSortKey(Token, CompareOptions.StringSort).KeyData);
        }

        public static string ToRavenId(string key)
        {
            return IdPrefix + Convert.ToBase64String(CultureInfo.InvariantCulture.CompareInfo.GetSortKey(key, CompareOptions.StringSort).KeyData);
        }
```        

The GetSortKey will ensure that the representation of the string is unique. Therefore each time that we perform a .Load operation we are actually pointing to the proper entity.
