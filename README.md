# TinsoftProxy-Multi-Threads
TinsoftProxy Multi Threads C#
How to use
-Dynamic Multi Proxies:

Creat a null Oject as starting Object<br/>
<code>DynamicMultiProxies myProxies;</code><br/>

In main start function:<br/>
<code>
myProxies = new DynamicMultiProxies(); 
</code><br/>
<code>
myProxies.mySettings.limit_theads_use = 3; // max thread per IP 
</code><br/>
<code>
myProxies.mySettings.min_get_timeout = 180; // min of IP timeout to use
</code><br/>
<code>
   //... use for loop for adding multi keys </code><br/>
<code>
   myProxies.Start(); //start auto get IP for all keys<br/>
</code><br/><br/>
In running thread:<br/>
+Get 1 IP:<br/>
  <code>
     string proxy = myProxies.getRandomProxy();<br/>
     //or ...<br/>
     string proxy = myProxies.getProxy();<br/>
  </code><br/><br/>
 +When Thread complete:<br/>
 <code>
      myProxies.setThreadStop(proxy);<br/>
  </code><br/><br/>
  In main Stop function:<br/>
   <code>
      myProxies.Stop();
  </code><br/><br/>
 
