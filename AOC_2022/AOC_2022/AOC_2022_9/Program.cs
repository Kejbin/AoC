﻿// See https://aka.ms/new-console-template for more information
var input = "L 1\r\nD 2\r\nR 2\r\nL 1\r\nD 1\r\nL 1\r\nU 1\r\nR 1\r\nL 2\r\nR 2\r\nL 2\r\nD 1\r\nR 2\r\nD 1\r\nU 2\r\nR 2\r\nD 1\r\nR 1\r\nL 2\r\nR 1\r\nD 1\r\nU 2\r\nR 2\r\nD 1\r\nR 2\r\nL 1\r\nD 1\r\nU 1\r\nR 1\r\nD 2\r\nL 1\r\nD 1\r\nL 1\r\nU 1\r\nL 2\r\nU 1\r\nL 1\r\nU 1\r\nL 1\r\nD 2\r\nR 2\r\nU 1\r\nD 2\r\nR 1\r\nU 1\r\nD 1\r\nR 1\r\nU 2\r\nL 2\r\nD 2\r\nR 1\r\nU 2\r\nL 2\r\nU 1\r\nD 1\r\nL 1\r\nR 2\r\nL 2\r\nR 1\r\nD 2\r\nL 1\r\nD 2\r\nL 1\r\nR 2\r\nU 2\r\nD 2\r\nU 1\r\nR 2\r\nD 2\r\nL 2\r\nU 1\r\nD 2\r\nR 1\r\nL 2\r\nR 1\r\nL 2\r\nU 2\r\nD 2\r\nU 2\r\nD 2\r\nR 1\r\nU 2\r\nL 2\r\nD 1\r\nU 2\r\nL 1\r\nD 1\r\nR 2\r\nU 1\r\nL 1\r\nD 1\r\nU 2\r\nD 2\r\nR 2\r\nU 1\r\nL 2\r\nD 2\r\nL 1\r\nD 2\r\nL 1\r\nU 1\r\nR 2\r\nL 2\r\nD 1\r\nR 2\r\nU 2\r\nR 2\r\nL 2\r\nD 1\r\nR 1\r\nL 1\r\nD 2\r\nU 2\r\nL 1\r\nD 1\r\nR 1\r\nL 3\r\nU 2\r\nR 2\r\nD 3\r\nL 1\r\nR 3\r\nL 1\r\nR 2\r\nD 1\r\nU 3\r\nL 1\r\nU 2\r\nL 1\r\nD 3\r\nR 3\r\nD 1\r\nU 3\r\nR 2\r\nD 2\r\nR 2\r\nL 1\r\nU 1\r\nR 1\r\nU 2\r\nR 3\r\nU 1\r\nD 1\r\nU 1\r\nR 3\r\nD 2\r\nR 2\r\nU 3\r\nD 1\r\nR 3\r\nL 3\r\nU 3\r\nD 3\r\nR 1\r\nD 3\r\nL 1\r\nD 3\r\nL 1\r\nR 1\r\nU 1\r\nL 2\r\nD 3\r\nU 3\r\nD 2\r\nU 3\r\nD 2\r\nU 2\r\nD 1\r\nR 2\r\nU 3\r\nL 1\r\nR 2\r\nL 3\r\nU 3\r\nD 3\r\nL 2\r\nR 2\r\nU 3\r\nR 1\r\nL 1\r\nU 1\r\nD 1\r\nR 2\r\nL 3\r\nU 3\r\nD 1\r\nL 1\r\nU 1\r\nR 1\r\nD 2\r\nL 2\r\nD 2\r\nR 3\r\nD 2\r\nR 3\r\nD 2\r\nR 1\r\nD 1\r\nR 3\r\nD 1\r\nU 1\r\nL 1\r\nR 2\r\nD 3\r\nL 3\r\nR 1\r\nL 2\r\nR 1\r\nU 3\r\nD 2\r\nR 1\r\nU 1\r\nL 2\r\nR 2\r\nL 2\r\nD 1\r\nU 3\r\nR 3\r\nD 2\r\nR 1\r\nU 2\r\nL 3\r\nR 1\r\nD 1\r\nU 2\r\nL 4\r\nD 2\r\nR 1\r\nU 4\r\nR 4\r\nD 3\r\nR 3\r\nU 2\r\nL 2\r\nU 1\r\nD 3\r\nU 2\r\nD 2\r\nR 4\r\nD 3\r\nR 3\r\nD 4\r\nR 2\r\nU 2\r\nL 1\r\nD 1\r\nL 2\r\nU 4\r\nD 4\r\nR 3\r\nU 2\r\nR 3\r\nU 4\r\nD 2\r\nR 3\r\nD 4\r\nL 3\r\nD 1\r\nR 4\r\nD 4\r\nR 4\r\nL 3\r\nU 1\r\nL 1\r\nD 4\r\nL 3\r\nD 1\r\nU 2\r\nR 4\r\nU 1\r\nL 4\r\nD 3\r\nU 2\r\nR 4\r\nD 3\r\nU 3\r\nL 4\r\nU 2\r\nR 1\r\nU 1\r\nD 3\r\nR 3\r\nD 1\r\nU 1\r\nL 3\r\nR 1\r\nD 2\r\nR 4\r\nU 2\r\nD 4\r\nU 4\r\nL 4\r\nR 4\r\nD 2\r\nR 3\r\nD 3\r\nR 4\r\nU 1\r\nD 3\r\nR 4\r\nL 1\r\nU 1\r\nL 1\r\nD 4\r\nR 1\r\nU 4\r\nL 3\r\nR 2\r\nU 4\r\nR 3\r\nU 1\r\nL 3\r\nD 2\r\nL 2\r\nR 3\r\nD 1\r\nL 4\r\nD 2\r\nR 3\r\nL 4\r\nR 4\r\nL 2\r\nU 1\r\nD 1\r\nR 3\r\nU 4\r\nD 4\r\nU 4\r\nD 4\r\nR 4\r\nU 4\r\nD 1\r\nU 1\r\nD 4\r\nU 1\r\nD 4\r\nU 4\r\nR 4\r\nD 4\r\nL 4\r\nD 1\r\nU 5\r\nR 5\r\nU 5\r\nL 1\r\nR 4\r\nU 5\r\nL 2\r\nU 4\r\nD 1\r\nR 1\r\nL 4\r\nD 2\r\nL 5\r\nD 5\r\nR 3\r\nL 2\r\nR 1\r\nU 1\r\nR 5\r\nD 2\r\nU 1\r\nL 1\r\nD 4\r\nU 4\r\nL 2\r\nU 4\r\nL 1\r\nD 4\r\nL 1\r\nU 4\r\nL 3\r\nU 3\r\nD 2\r\nL 3\r\nD 2\r\nL 3\r\nR 1\r\nL 2\r\nU 1\r\nL 2\r\nR 2\r\nD 5\r\nU 4\r\nR 1\r\nD 5\r\nU 2\r\nR 3\r\nU 4\r\nL 4\r\nR 5\r\nL 2\r\nR 5\r\nU 5\r\nD 3\r\nR 2\r\nD 1\r\nR 2\r\nU 4\r\nD 1\r\nR 4\r\nD 5\r\nR 4\r\nL 4\r\nU 5\r\nD 1\r\nL 2\r\nR 1\r\nU 3\r\nL 5\r\nR 5\r\nL 2\r\nD 3\r\nL 2\r\nR 3\r\nU 2\r\nD 2\r\nU 3\r\nL 5\r\nU 3\r\nD 1\r\nR 1\r\nD 3\r\nL 2\r\nU 1\r\nD 2\r\nU 4\r\nL 4\r\nU 5\r\nR 5\r\nU 5\r\nL 5\r\nR 3\r\nL 1\r\nD 1\r\nL 3\r\nD 4\r\nR 1\r\nD 1\r\nR 3\r\nL 4\r\nU 4\r\nL 1\r\nR 5\r\nD 4\r\nU 2\r\nD 6\r\nU 6\r\nL 6\r\nU 2\r\nL 2\r\nD 6\r\nU 2\r\nR 2\r\nU 1\r\nR 6\r\nD 6\r\nR 5\r\nL 4\r\nR 3\r\nD 4\r\nL 6\r\nU 1\r\nD 2\r\nL 5\r\nU 2\r\nD 1\r\nU 6\r\nR 4\r\nL 4\r\nU 3\r\nL 3\r\nU 6\r\nL 4\r\nR 4\r\nL 5\r\nU 2\r\nL 1\r\nU 1\r\nD 5\r\nU 4\r\nD 5\r\nL 5\r\nU 3\r\nR 6\r\nU 5\r\nD 6\r\nR 3\r\nD 1\r\nL 3\r\nR 5\r\nU 5\r\nR 4\r\nD 3\r\nU 1\r\nD 1\r\nR 1\r\nD 1\r\nL 6\r\nU 2\r\nD 4\r\nU 6\r\nD 4\r\nL 6\r\nD 4\r\nR 6\r\nU 4\r\nR 2\r\nD 2\r\nU 1\r\nL 2\r\nU 5\r\nD 4\r\nL 2\r\nD 1\r\nL 3\r\nR 1\r\nL 1\r\nR 6\r\nL 3\r\nU 5\r\nD 3\r\nR 5\r\nU 1\r\nD 5\r\nR 4\r\nD 2\r\nU 6\r\nR 1\r\nU 3\r\nD 2\r\nR 1\r\nU 6\r\nR 2\r\nU 5\r\nR 4\r\nD 6\r\nU 1\r\nR 2\r\nD 6\r\nU 5\r\nR 1\r\nD 6\r\nU 2\r\nL 3\r\nU 3\r\nD 1\r\nR 4\r\nD 1\r\nL 3\r\nR 4\r\nU 2\r\nR 6\r\nL 3\r\nR 6\r\nU 6\r\nD 1\r\nR 4\r\nD 2\r\nU 6\r\nD 3\r\nR 2\r\nL 1\r\nD 5\r\nL 6\r\nR 4\r\nD 3\r\nR 2\r\nU 2\r\nR 4\r\nD 1\r\nU 2\r\nL 6\r\nD 3\r\nL 3\r\nD 6\r\nL 4\r\nU 6\r\nD 2\r\nR 3\r\nD 7\r\nL 7\r\nR 4\r\nD 2\r\nL 1\r\nR 7\r\nL 7\r\nU 7\r\nD 3\r\nR 2\r\nL 4\r\nD 1\r\nL 2\r\nU 6\r\nD 6\r\nR 5\r\nL 5\r\nU 3\r\nL 5\r\nR 2\r\nL 5\r\nU 3\r\nD 6\r\nL 1\r\nD 3\r\nL 7\r\nU 1\r\nR 7\r\nD 1\r\nR 2\r\nU 5\r\nL 3\r\nD 2\r\nL 2\r\nR 2\r\nU 2\r\nR 1\r\nL 5\r\nU 2\r\nD 2\r\nU 1\r\nR 4\r\nD 4\r\nL 6\r\nD 3\r\nU 4\r\nL 3\r\nD 3\r\nU 2\r\nL 4\r\nD 2\r\nR 3\r\nL 6\r\nR 3\r\nD 6\r\nU 1\r\nR 3\r\nU 7\r\nD 5\r\nL 1\r\nR 7\r\nL 5\r\nR 1\r\nD 7\r\nU 4\r\nL 3\r\nR 4\r\nD 1\r\nL 5\r\nD 3\r\nR 6\r\nU 5\r\nL 5\r\nR 5\r\nD 5\r\nU 7\r\nR 1\r\nD 1\r\nU 5\r\nD 3\r\nR 2\r\nU 6\r\nD 5\r\nU 3\r\nL 3\r\nR 4\r\nL 8\r\nU 2\r\nR 1\r\nU 4\r\nR 5\r\nL 6\r\nU 4\r\nR 3\r\nD 2\r\nU 7\r\nR 7\r\nD 1\r\nU 1\r\nL 3\r\nR 4\r\nU 6\r\nL 8\r\nD 4\r\nR 5\r\nD 6\r\nL 1\r\nR 8\r\nU 2\r\nL 7\r\nU 5\r\nR 4\r\nU 1\r\nD 1\r\nR 8\r\nL 6\r\nD 6\r\nR 1\r\nD 1\r\nU 2\r\nR 1\r\nL 6\r\nR 5\r\nU 1\r\nD 1\r\nL 2\r\nU 7\r\nR 4\r\nD 6\r\nL 3\r\nD 7\r\nU 1\r\nR 7\r\nD 1\r\nR 6\r\nL 2\r\nD 4\r\nL 3\r\nR 7\r\nL 7\r\nU 8\r\nR 7\r\nL 5\r\nD 8\r\nR 1\r\nD 4\r\nL 3\r\nR 7\r\nL 4\r\nU 7\r\nL 3\r\nD 7\r\nL 4\r\nR 8\r\nL 5\r\nD 2\r\nR 3\r\nU 6\r\nD 1\r\nL 7\r\nD 1\r\nU 2\r\nD 8\r\nU 7\r\nR 1\r\nU 8\r\nL 4\r\nU 4\r\nD 5\r\nR 2\r\nD 7\r\nR 5\r\nL 4\r\nD 4\r\nU 4\r\nD 5\r\nU 2\r\nD 5\r\nR 8\r\nD 7\r\nU 2\r\nD 7\r\nR 3\r\nU 6\r\nL 6\r\nD 5\r\nL 5\r\nR 3\r\nU 5\r\nR 5\r\nL 3\r\nD 3\r\nR 3\r\nD 5\r\nR 6\r\nD 3\r\nL 1\r\nU 6\r\nR 4\r\nD 4\r\nR 8\r\nD 6\r\nL 8\r\nD 2\r\nU 1\r\nL 9\r\nR 8\r\nD 6\r\nL 8\r\nR 6\r\nL 8\r\nU 4\r\nL 6\r\nR 5\r\nU 1\r\nL 5\r\nR 8\r\nD 3\r\nL 8\r\nR 9\r\nU 9\r\nL 5\r\nD 5\r\nR 2\r\nD 1\r\nU 4\r\nR 1\r\nU 2\r\nR 2\r\nL 8\r\nD 1\r\nL 3\r\nD 2\r\nU 1\r\nL 8\r\nR 5\r\nL 2\r\nD 9\r\nU 4\r\nL 5\r\nD 3\r\nU 4\r\nD 8\r\nL 4\r\nU 1\r\nL 1\r\nD 2\r\nU 6\r\nD 8\r\nU 3\r\nD 2\r\nU 3\r\nR 5\r\nU 6\r\nL 1\r\nU 1\r\nL 8\r\nD 9\r\nL 4\r\nU 4\r\nR 3\r\nD 6\r\nU 5\r\nL 8\r\nD 4\r\nU 4\r\nL 8\r\nR 6\r\nL 4\r\nU 5\r\nR 5\r\nU 4\r\nD 4\r\nU 4\r\nR 7\r\nL 8\r\nU 6\r\nL 9\r\nR 8\r\nU 5\r\nL 2\r\nU 5\r\nD 3\r\nL 7\r\nD 4\r\nR 1\r\nU 3\r\nR 6\r\nL 9\r\nR 8\r\nU 8\r\nL 7\r\nR 1\r\nL 1\r\nU 3\r\nD 8\r\nR 3\r\nD 1\r\nL 5\r\nD 2\r\nR 4\r\nU 9\r\nL 1\r\nR 1\r\nL 5\r\nR 4\r\nU 8\r\nD 6\r\nU 6\r\nR 9\r\nL 3\r\nR 9\r\nU 1\r\nR 9\r\nD 5\r\nL 4\r\nR 6\r\nL 3\r\nR 2\r\nU 9\r\nD 8\r\nR 4\r\nL 6\r\nR 5\r\nL 6\r\nU 6\r\nR 8\r\nU 10\r\nL 2\r\nR 1\r\nD 8\r\nL 9\r\nU 4\r\nD 1\r\nL 9\r\nR 6\r\nU 7\r\nD 7\r\nL 6\r\nR 6\r\nU 2\r\nL 3\r\nU 6\r\nR 4\r\nL 10\r\nR 1\r\nL 5\r\nU 2\r\nR 6\r\nD 2\r\nR 9\r\nL 4\r\nU 4\r\nD 1\r\nL 7\r\nR 8\r\nL 1\r\nD 9\r\nL 6\r\nU 6\r\nL 10\r\nU 1\r\nL 2\r\nR 2\r\nU 3\r\nL 5\r\nD 4\r\nL 8\r\nD 7\r\nL 5\r\nR 3\r\nD 7\r\nU 10\r\nD 10\r\nR 8\r\nD 3\r\nR 7\r\nD 5\r\nR 10\r\nD 9\r\nR 6\r\nL 3\r\nR 1\r\nU 8\r\nL 3\r\nR 9\r\nU 4\r\nD 3\r\nR 8\r\nD 10\r\nU 5\r\nD 8\r\nL 3\r\nD 8\r\nL 3\r\nD 6\r\nR 6\r\nD 1\r\nR 3\r\nD 10\r\nR 4\r\nL 2\r\nR 10\r\nD 4\r\nU 1\r\nL 9\r\nR 9\r\nD 10\r\nU 4\r\nD 2\r\nL 5\r\nR 8\r\nL 2\r\nR 4\r\nU 5\r\nD 1\r\nL 3\r\nU 4\r\nD 7\r\nL 11\r\nR 2\r\nL 1\r\nD 3\r\nR 8\r\nD 5\r\nU 6\r\nL 11\r\nD 7\r\nU 3\r\nR 4\r\nL 6\r\nU 2\r\nD 1\r\nR 5\r\nU 9\r\nL 3\r\nU 4\r\nR 9\r\nD 11\r\nR 1\r\nU 8\r\nL 7\r\nR 6\r\nD 11\r\nU 8\r\nR 3\r\nD 8\r\nU 6\r\nR 8\r\nU 8\r\nD 9\r\nU 6\r\nR 7\r\nU 11\r\nL 10\r\nU 11\r\nL 10\r\nU 10\r\nR 11\r\nU 10\r\nL 10\r\nR 6\r\nL 11\r\nD 1\r\nL 5\r\nD 4\r\nR 1\r\nL 4\r\nU 2\r\nD 8\r\nL 10\r\nR 8\r\nD 10\r\nL 2\r\nD 5\r\nL 11\r\nR 6\r\nL 9\r\nU 3\r\nL 1\r\nR 11\r\nL 8\r\nD 5\r\nU 11\r\nD 10\r\nR 5\r\nU 9\r\nL 4\r\nU 5\r\nR 8\r\nL 8\r\nU 1\r\nL 11\r\nU 6\r\nR 6\r\nD 5\r\nR 5\r\nL 4\r\nU 2\r\nL 6\r\nD 3\r\nL 9\r\nR 6\r\nU 3\r\nD 11\r\nR 1\r\nD 11\r\nU 4\r\nR 9\r\nD 3\r\nL 7\r\nD 7\r\nL 11\r\nD 5\r\nL 5\r\nD 8\r\nR 10\r\nU 2\r\nL 6\r\nU 10\r\nD 10\r\nR 4\r\nD 6\r\nU 10\r\nR 3\r\nU 5\r\nR 4\r\nU 3\r\nD 11\r\nR 7\r\nD 10\r\nL 6\r\nU 2\r\nL 11\r\nD 12\r\nL 8\r\nU 11\r\nD 10\r\nL 2\r\nD 10\r\nL 2\r\nR 3\r\nD 6\r\nL 9\r\nD 9\r\nU 2\r\nL 5\r\nR 3\r\nU 3\r\nD 1\r\nU 7\r\nL 5\r\nR 2\r\nU 7\r\nD 12\r\nU 5\r\nL 1\r\nR 3\r\nD 8\r\nU 3\r\nD 12\r\nR 5\r\nL 11\r\nU 5\r\nL 2\r\nR 3\r\nL 7\r\nR 9\r\nU 5\r\nD 3\r\nL 4\r\nD 8\r\nU 6\r\nR 11\r\nD 10\r\nU 3\r\nR 4\r\nL 3\r\nR 9\r\nU 7\r\nD 5\r\nL 10\r\nR 1\r\nU 8\r\nD 9\r\nL 12\r\nR 6\r\nD 11\r\nU 7\r\nD 11\r\nR 2\r\nD 9\r\nR 11\r\nU 12\r\nR 2\r\nD 11\r\nR 5\r\nL 1\r\nU 6\r\nD 4\r\nL 7\r\nU 10\r\nL 5\r\nD 8\r\nR 7\r\nL 7\r\nR 6\r\nU 7\r\nL 9\r\nU 12\r\nL 9\r\nU 2\r\nR 6\r\nU 11\r\nL 2\r\nD 3\r\nR 3\r\nU 3\r\nR 8\r\nD 5\r\nR 10\r\nD 12\r\nR 1\r\nD 3\r\nU 8\r\nD 2\r\nL 4\r\nU 7\r\nR 1\r\nL 11\r\nR 7\r\nU 11\r\nD 3\r\nR 9\r\nL 1\r\nD 1\r\nR 11\r\nL 12\r\nR 1\r\nU 11\r\nR 9\r\nL 12\r\nR 5\r\nD 11\r\nR 10\r\nU 3\r\nL 13\r\nU 11\r\nL 11\r\nR 3\r\nL 1\r\nU 12\r\nL 7\r\nU 2\r\nD 7\r\nU 9\r\nR 2\r\nU 7\r\nL 10\r\nR 9\r\nU 13\r\nD 8\r\nR 7\r\nD 7\r\nL 1\r\nU 2\r\nL 9\r\nD 9\r\nL 13\r\nR 13\r\nL 12\r\nU 3\r\nL 1\r\nR 5\r\nD 8\r\nU 2\r\nD 12\r\nR 9\r\nD 11\r\nR 12\r\nL 10\r\nU 9\r\nR 1\r\nU 11\r\nL 5\r\nR 10\r\nL 7\r\nR 9\r\nU 11\r\nD 3\r\nR 13\r\nL 11\r\nU 4\r\nR 1\r\nU 7\r\nL 2\r\nR 3\r\nL 6\r\nD 4\r\nR 8\r\nL 8\r\nU 10\r\nD 12\r\nU 9\r\nR 7\r\nD 1\r\nR 8\r\nU 7\r\nR 1\r\nD 8\r\nL 6\r\nD 13\r\nL 6\r\nR 4\r\nU 13\r\nL 2\r\nR 5\r\nD 2\r\nU 1\r\nL 6\r\nR 7\r\nD 11\r\nL 9\r\nR 11\r\nU 3\r\nL 8\r\nR 6\r\nL 10\r\nU 9\r\nR 1\r\nU 3\r\nR 1\r\nL 6\r\nR 4\r\nL 3\r\nD 8\r\nU 3\r\nD 3\r\nU 8\r\nL 12\r\nR 5\r\nL 3\r\nD 8\r\nL 7\r\nD 3\r\nR 5\r\nL 3\r\nR 11\r\nL 4\r\nU 6\r\nR 7\r\nL 11\r\nD 4\r\nR 5\r\nU 6\r\nR 13\r\nD 11\r\nU 2\r\nD 12\r\nL 8\r\nR 3\r\nD 4\r\nL 12\r\nD 7\r\nR 14\r\nU 8\r\nR 12\r\nU 14\r\nR 1\r\nL 3\r\nR 13\r\nU 14\r\nD 12\r\nR 4\r\nU 4\r\nR 14\r\nD 10\r\nU 11\r\nR 10\r\nD 13\r\nU 8\r\nR 13\r\nL 9\r\nU 6\r\nD 7\r\nU 9\r\nL 11\r\nU 10\r\nL 14\r\nU 7\r\nL 5\r\nD 1\r\nU 8\r\nR 14\r\nU 12\r\nL 1\r\nR 4\r\nL 7\r\nD 2\r\nR 5\r\nD 3\r\nR 14\r\nU 6\r\nD 7\r\nR 2\r\nL 8\r\nU 14\r\nD 12\r\nU 12\r\nL 5\r\nD 5\r\nL 1\r\nU 3\r\nL 10\r\nR 4\r\nU 2\r\nR 11\r\nD 6\r\nU 12\r\nD 5\r\nU 11\r\nD 5\r\nL 8\r\nD 1\r\nL 7\r\nD 1\r\nU 9\r\nD 6\r\nL 10\r\nD 7\r\nL 10\r\nR 7\r\nD 11\r\nL 9\r\nU 13\r\nD 10\r\nU 10\r\nR 13\r\nL 2\r\nR 13\r\nU 3\r\nR 8\r\nD 7\r\nL 2\r\nU 1\r\nL 7\r\nD 11\r\nU 6\r\nD 12\r\nL 3\r\nR 3\r\nD 1\r\nR 2\r\nD 2\r\nU 4\r\nD 1\r\nL 12\r\nU 5\r\nL 3\r\nR 13\r\nD 9\r\nL 3\r\nD 10\r\nL 5\r\nR 13\r\nD 9\r\nL 7\r\nR 12\r\nL 8\r\nU 1\r\nR 5\r\nL 3\r\nD 7\r\nR 4\r\nU 6\r\nR 4\r\nU 15\r\nD 13\r\nR 3\r\nL 14\r\nR 1\r\nU 3\r\nR 4\r\nU 12\r\nR 7\r\nD 7\r\nU 1\r\nR 12\r\nD 9\r\nR 14\r\nU 10\r\nR 1\r\nU 6\r\nD 10\r\nR 14\r\nD 12\r\nR 6\r\nD 13\r\nU 14\r\nR 15\r\nU 9\r\nL 6\r\nR 7\r\nL 13\r\nR 4\r\nD 8\r\nR 2\r\nL 6\r\nU 13\r\nL 15\r\nD 5\r\nU 4\r\nR 14\r\nD 5\r\nL 6\r\nU 3\r\nR 10\r\nL 12\r\nU 9\r\nD 5\r\nL 4\r\nU 1\r\nR 10\r\nL 3\r\nU 5\r\nR 12\r\nD 14\r\nL 10\r\nR 9\r\nD 2\r\nU 6\r\nD 6\r\nU 1\r\nL 8\r\nR 3\r\nD 8\r\nR 1\r\nD 5\r\nL 10\r\nD 11\r\nL 5\r\nR 6\r\nD 8\r\nR 2\r\nD 12\r\nL 7\r\nR 14\r\nD 8\r\nL 8\r\nU 14\r\nR 13\r\nL 7\r\nD 8\r\nU 3\r\nL 6\r\nU 6\r\nD 4\r\nR 9\r\nL 11\r\nR 2\r\nU 10\r\nR 14\r\nD 8\r\nR 2\r\nU 10\r\nR 7\r\nU 3\r\nR 4\r\nD 9\r\nU 9\r\nD 11\r\nU 5\r\nD 9\r\nR 14\r\nU 13\r\nD 5\r\nL 7\r\nR 2\r\nD 9\r\nR 2\r\nU 9\r\nD 8\r\nL 12\r\nR 12\r\nL 3\r\nR 6\r\nU 16\r\nR 15\r\nD 8\r\nU 3\r\nR 1\r\nL 8\r\nD 11\r\nL 6\r\nR 5\r\nL 14\r\nD 15\r\nU 1\r\nR 10\r\nD 11\r\nR 16\r\nD 1\r\nU 6\r\nL 12\r\nU 3\r\nD 9\r\nU 1\r\nD 13\r\nL 14\r\nR 8\r\nL 9\r\nD 3\r\nU 16\r\nR 3\r\nL 11\r\nR 13\r\nL 10\r\nU 10\r\nL 3\r\nR 7\r\nL 6\r\nR 2\r\nD 4\r\nU 15\r\nR 13\r\nU 10\r\nD 1\r\nL 3\r\nD 15\r\nL 9\r\nR 8\r\nD 14\r\nR 11\r\nL 11\r\nD 4\r\nU 15\r\nL 2\r\nU 4\r\nD 3\r\nU 6\r\nD 5\r\nU 15\r\nL 8\r\nD 14\r\nR 1\r\nU 8\r\nL 7\r\nD 8\r\nR 8\r\nU 1\r\nD 8\r\nR 11\r\nD 4\r\nU 14\r\nR 11\r\nD 16\r\nU 4\r\nD 9\r\nR 11\r\nL 16\r\nD 5\r\nL 9\r\nR 6\r\nU 9\r\nD 16\r\nR 4\r\nL 11\r\nU 11\r\nD 6\r\nU 13\r\nD 14\r\nU 13\r\nL 8\r\nU 9\r\nD 3\r\nR 4\r\nL 8\r\nD 7\r\nL 12\r\nD 6\r\nR 14\r\nL 11\r\nU 7\r\nD 4\r\nU 1\r\nL 11\r\nU 15\r\nL 5\r\nD 8\r\nU 2\r\nR 15\r\nL 5\r\nR 7\r\nL 8\r\nR 15\r\nU 8\r\nD 7\r\nU 17\r\nD 5\r\nU 15\r\nR 8\r\nU 15\r\nL 7\r\nU 5\r\nD 11\r\nL 4\r\nU 11\r\nD 13\r\nR 10\r\nD 12\r\nL 16\r\nD 9\r\nL 17\r\nU 1\r\nR 10\r\nD 1\r\nR 16\r\nU 6\r\nL 2\r\nD 7\r\nU 8\r\nD 12\r\nL 15\r\nU 16\r\nR 5\r\nL 13\r\nD 2\r\nU 7\r\nL 14\r\nD 6\r\nL 8\r\nR 12\r\nU 4\r\nD 7\r\nU 4\r\nR 3\r\nU 8\r\nD 5\r\nL 4\r\nU 3\r\nR 13\r\nL 14\r\nR 7\r\nU 11\r\nD 9\r\nR 1\r\nD 15\r\nR 11\r\nL 8\r\nR 7\r\nD 17\r\nU 13\r\nR 15\r\nD 5\r\nR 15\r\nU 7\r\nR 10\r\nU 14\r\nD 2\r\nL 7\r\nR 13\r\nD 10\r\nU 16\r\nD 6\r\nR 10\r\nD 4\r\nU 1\r\nR 14\r\nU 2\r\nL 2\r\nU 1\r\nL 13\r\nD 2\r\nU 16\r\nD 1\r\nU 8\r\nL 7\r\nU 17\r\nD 9\r\nL 10\r\nU 16\r\nD 13\r\nU 15\r\nD 12\r\nL 6\r\nD 9\r\nL 3\r\nR 17\r\nU 16\r\nL 6\r\nD 11\r\nR 11\r\nL 11\r\nU 2\r\nR 15\r\nD 11\r\nR 10\r\nU 2\r\nD 18\r\nU 18\r\nD 18\r\nL 4\r\nU 1\r\nR 1\r\nL 7\r\nU 7\r\nL 12\r\nU 10\r\nR 13\r\nD 16\r\nR 1\r\nD 11\r\nL 12\r\nR 7\r\nD 13\r\nL 10\r\nD 6\r\nU 1\r\nL 14\r\nR 13\r\nD 14\r\nL 3\r\nD 18\r\nL 2\r\nU 9\r\nL 7\r\nR 18\r\nL 11\r\nU 16\r\nR 9\r\nU 8\r\nD 5\r\nL 15\r\nR 16\r\nD 17\r\nU 16\r\nL 10\r\nU 4\r\nR 1\r\nL 10\r\nU 4\r\nL 8\r\nU 5\r\nL 5\r\nR 18\r\nU 11\r\nR 18\r\nU 12\r\nD 18\r\nR 9\r\nL 2\r\nD 10\r\nL 15\r\nD 2\r\nR 7\r\nD 16\r\nL 4\r\nR 13\r\nL 4\r\nR 2\r\nL 14\r\nD 4\r\nR 15\r\nD 14\r\nR 13\r\nL 9\r\nD 1\r\nU 7\r\nR 17\r\nL 6\r\nU 1\r\nL 6\r\nD 6\r\nU 5\r\nL 5\r\nR 10\r\nU 1\r\nR 9\r\nU 3\r\nD 2\r\nL 4\r\nU 1\r\nD 12\r\nR 5\r\nU 3\r\nR 15\r\nL 18\r\nR 3\r\nD 1\r\nL 6\r\nD 16\r\nU 15\r\nD 6\r\nR 8\r\nD 4\r\nR 14\r\nU 10\r\nR 10\r\nD 5\r\nL 14\r\nU 6\r\nL 15\r\nR 10\r\nD 17\r\nR 7\r\nL 13\r\nR 12\r\nD 4\r\nR 11\r\nD 2\r\nL 1\r\nR 13\r\nU 6\r\nD 16\r\nR 5\r\nD 17\r\nU 17\r\nD 11\r\nR 15\r\nL 4\r\nD 13\r\nL 11\r\nU 16\r\nL 3\r\nD 5\r\nU 1\r\nR 16\r\nL 10\r\nU 7\r\nD 9\r\nR 10\r\nL 4\r\nD 4\r\nL 7\r\nD 12\r\nU 5\r\nD 10\r\nR 2\r\nL 9\r\nD 6\r\nU 14\r\nR 4\r\nU 2\r\nL 19\r\nR 15\r\nL 13\r\nR 12\r\nL 8\r\nD 15\r\nU 13\r\nL 4\r\nU 13\r\nD 3\r\nU 7\r\nL 10\r\nR 8\r\nD 14\r\nR 3\r\nL 10\r\nD 3\r\nU 5\r\nL 15\r\nR 5\r\nL 2\r\nR 10\r\nD 5\r\nR 13\r\nL 18\r\nR 7\r\nL 6\r\nU 12\r\nD 16\r\nR 3\r\nL 11\r\nD 7\r\nR 1\r\nU 9\r\nR 9\r\nD 6\r\nL 1\r\nD 13\r\nU 10\r\nL 17\r\nR 10\r\nL 12\r\nR 8\r\nD 10\r\nR 12\r\nU 12\r\nD 14\r\nU 1\r\nD 4\r\nU 2\r\nL 9\r\nR 3\r\nU 2\r\nR 19\r\nD 1\r\nL 4\r\nR 6\r\nL 4\r\nD 4\r\nR 16\r\nD 17\r\nR 3\r\nD 9\r\nL 8\r\nR 15\r\nD 4\r\nU 13\r\nD 4\r\nU 17\r\nD 15\r\nL 17\r\nD 1\r\nR 14\r\nL 18\r\nU 2\r\nR 11\r\nU 5";
var inputArray = input.Split(Environment.NewLine);
var positionCounter = 0;
var positions = new HashSet<(int X, int Y)> { (0, 0) };
var currentPos = (X: 0, Y: 0);

foreach (var move in inputArray)
{
    var directionAndSteps = move.Split(" ");

	switch (directionAndSteps[0])
	{
		case "U":
            MoveBy(0, int.Parse(directionAndSteps[1]));
			break;
        case "D":
            MoveBy(0, -int.Parse(directionAndSteps[1]));
            break;
        case "L":
            MoveBy(-int.Parse(directionAndSteps[1]), 0);
            break;
        case "R":
            MoveBy(int.Parse(directionAndSteps[1]), 0);
            break;
        default:
			break;
	}
}

void MoveBy(int x, int y)
{
    if (x != 0)
        for (int i = 1; i <= Math.Abs(x); i++)
        {
            var pos = (X: currentPos.X + i * x / Math.Abs(x), Y: currentPos.Y);
            if (!positions.Contains(pos))
                positions.Add(pos);

            if (Math.Abs(x) == i)
                currentPos = pos;
        }

    if (y != 0)
    {
        for (int i = 1; i <= Math.Abs(y); i++)
        {
            var pos = (X: currentPos.X, Y: currentPos.Y + i * y / Math.Abs(y));
            if (!positions.Contains(pos))
                positions.Add(pos);

            if (Math.Abs(y) == i)
                currentPos = pos;
        }

    }
}

Console.WriteLine(positions.Count);