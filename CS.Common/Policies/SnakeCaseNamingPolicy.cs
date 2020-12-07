using CS.Common.Helpers;
using System.Text.Json;

namespace CS.Common.Policies
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="JsonNamingPolicy" />
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();

        /// <summary>
        /// When overridden in a derived class, converts the specified name according to the policy.
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>
        /// The converted name.
        /// </returns>
        public override string ConvertName(string name)
        {
            // Conversion to other naming conventaion goes here. Like SnakeCase, KebabCase etc.
            return name.ToSnakeCase();
        }
    }
}
