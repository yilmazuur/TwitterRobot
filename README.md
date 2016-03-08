# TwitterRobot

This application can be used for following or unfollowing 500-1000 people at a time. You should give a twitter name that contains people(as follower) you want to follow.
Assume there is a popular account named "AccA" related to your account "AccB" somehow. 
If you want followers of AccA to follow your account AccB too, you can poke them by following them for a while.
You should give name of the AccA in middle textbox and then click "follower sayısı" button.
After you specify the interval of follower amount, click "verilen aralığı takip et"

![alt tag](https://raw.githubusercontent.com/yilmazuur/TwitterRobot/master/twitterRobot.PNG)

Fill the twitter API key values (in the code) related to your account.
And you should check twitter API rate limits before using the app.
https://dev.twitter.com/rest/public/rate-limiting
You can unfollow users by clicking "500/1000 follow bırak" and the app keeps followed people in DB. That aims not following same people again and again. So, your account will not be annoying for others.

Note that the source code of this application is a little bit trash but it works :)

##License
```
The MIT License (MIT)

Copyright (c) 2016 Uğur Yılmaz

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
License located in `LICENSE.md`

