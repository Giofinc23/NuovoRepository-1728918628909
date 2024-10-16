using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace Conte.Car.Website.Cj.Helper
{
    public static class SessionConverter
    {
        public static KeyValuePair<Guid, bool> GetSessionId(StringValues sessionId)
        {
            var isS_ID_Guid = false;
            Guid s_id = Guid.Empty;

            if (!StringValues.IsNullOrEmpty(sessionId))
                isS_ID_Guid = Guid.TryParse(sessionId.ToString(), out s_id);
            else
                isS_ID_Guid = Guid.TryParse(sessionId, out s_id);

            return new KeyValuePair<Guid, bool>(s_id, isS_ID_Guid);
        }
        public static KeyValuePair<Guid, bool> ToGuid(StringValues value)
        {
            var isS_ID_Guid = false;
            Guid s_id = Guid.Empty;

            if (!StringValues.IsNullOrEmpty(value))
                isS_ID_Guid = Guid.TryParse(value.ToString(), out s_id);
            else
                isS_ID_Guid = Guid.TryParse(value, out s_id);

            return new KeyValuePair<Guid, bool>(s_id, isS_ID_Guid);
        }
        public static KeyValuePair<Guid, bool> GetSession(string sessionId)
        {
            var isS_ID_Guid = false;
            Guid s_id = Guid.Empty;

            if (!string.IsNullOrEmpty(sessionId))
                isS_ID_Guid = Guid.TryParse(sessionId, out s_id);            

            return new KeyValuePair<Guid, bool>(s_id, isS_ID_Guid);
        }
    }
}
