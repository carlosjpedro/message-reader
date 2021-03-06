﻿using ConsoleApp1.Exceptions;
using ConsoleApp1.Model;
using ConsoleApp1.Parsing;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class MessageParser : IMessageParser
    {
        private readonly IExtractIp _ipExtractor;
        private readonly IPortExtractor _portExtractor;
        private readonly ICodecExtractor _codecExtractor;

        public MessageParser(IExtractIp ipExtractor, IPortExtractor portExtractor, ICodecExtractor codecExtractor)
        {
            _ipExtractor = ipExtractor;
            _portExtractor = portExtractor;
            _codecExtractor = codecExtractor;
        }

        public NiceMessage Parse(List<string> messageLines)
        {
            string ip = null;
            int? port = null;
            List<string> codecs = new List<string>();
            
            try
            {
                foreach (var line in messageLines)
                {
                    var keyValue = line.Split('=');

                    if (keyValue.Length != 2)
                        throw new InvalidMessageFormat();

                    switch (keyValue[0])
                    {
                        case "c":
                            ip = _ipExtractor.Ip(keyValue[1]);
                            break;
                        case "m":
                            port = _portExtractor.Port(keyValue[1]);
                            break;
                        case "a":
                            var codec = _codecExtractor.Codec(keyValue[1]);
                            if (!string.IsNullOrWhiteSpace(codec))
                            {
                                codecs.Add(codec);
                            }
                            break;
                        default:
                            break;
                    }

                }

                if (!port.HasValue)
                {
                    throw new InvalidMessageFormat();
                }
                if (string.IsNullOrWhiteSpace(ip))
                {
                    throw new InvalidMessageFormat();
                }

                if (codecs.Count == 0)
                {
                    throw new InvalidMessageFormat();
                }
            }
            catch(InvalidMessageFormat)
            {
                return new InvalidNiceMessage(messageLines);
            }
            return new NiceMessage(ip, port.Value, codecs);
        }
    }


}
