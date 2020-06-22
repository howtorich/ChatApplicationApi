//using Amazon.Runtime.Internal.Transform;
//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq;
//using System.Runtime.InteropServices.ComTypes;
//using System.Security.Cryptography.X509Certificates;
//using System.Text.RegularExpressions;

//namespace SocialCommunicationModels.Validation
//{
//    public static class ModelValidation
//    {
//        public static void AddConstrain(this Dictionary<ValidationClass.Constraints, Func<string, bool>> dictionary, string[] arrg)
//        {

//        }
//    }

//    public class ValidationClass
//    {
//        public ValidationClass()
//        {
//            dicObject = new Dictionary<Constraints, Func<string, bool>>();
//            dicObject2 = new Dictionary<bool, string>();
//            dicObject.Add(Constraints.stringNotNullEmpty, stringNotNullEmpty);
//        }

//        //Dictionary<string, object> dicObject = new Dictionary<string, object>();
//        public Dictionary<Constraints, Func<string, bool>> dicObject;

//        public Dictionary<bool, string> dicObject2;



//        public enum Constraints
//        {
//            stringNotNullEmpty = 1,
//            LengthGreaterThan = 2,
//            LengthLessThan = 3,
//            stringEqals = 4,
//            Between = 5,
//            startWith = 6,
//            EndsWith = 7,
//            contains = 8,
//            emailValidation = 9,
//            NotNull = 10,
//            IsNull = 11,
//            stringIsNullEmpty = 12,

//        }

//        public Func<string, bool> stringNotNullEmpty = value => string.IsNullOrWhiteSpace(value) ? false : true;

//        public Func<(string value, int number), bool> LengthGreaterThan = param => param.value.Length > param.number ? true : false;

//        Func<(string value, int number), bool> LengthLessThan = param => param.value.Length < param.number ? true : false;

//        Func<(string value, string comparValue), bool> stringEqual = param => string.Equals(param.value, param.comparValue, StringComparison.OrdinalIgnoreCase);

//        Func<(int value, int from, int to), bool> between = param => param.value >= param.from && param.value <= param.to;

//        Func<(string value, string start), bool> startWith = param => param.value.StartsWith(param.start, StringComparison.OrdinalIgnoreCase);

//        Func<(string value, string ends), bool> endsWith = param => param.value.EndsWith(param.ends, StringComparison.OrdinalIgnoreCase);

//        Func<(string value, string contains), bool> contains = param => param.value.Contains(param.contains, StringComparison.OrdinalIgnoreCase);

//        Func<string, bool> emailvalidation = param => Regex.IsMatch(param, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

//        Func<string, bool> mobileValidation = param => Regex.IsMatch(param, @"^[1-9]\d{10}$", RegexOptions.IgnoreCase);

//        Func<object, bool> NotNull = param => param != null ? true : false;

//        Func<object, bool> IsNull = param => param == null ? true : false;

//        Func<string, bool> stringIsEmpty = param => string.IsNullOrWhiteSpace(param);


//        //Predicate<string> isUpper = s => s.Equals(s.ToUpper());

//        //bool result = isUpper("hello world!!");



//    }

//    public delegate bool stringNotsNull(string status);

//    public interface stringNotEmpty
//    {
//        event stringNotsNull notone;

//    }

//    public interface stringIsNull
//    {
//        public bool stringIsNull(string value);
//    }

//    public class validationOne : stringNotEmpty, stringIsNull
//    {
//        //stringNotsNull notone = value => string.IsNullOrWhiteSpace(value) ? false : true;

//        public bool stringIsNull(string value)
//        {

//            return "";
//        }

//        public bool notone(string value)
//        {
//            return false;
//        }


//    }


//}
