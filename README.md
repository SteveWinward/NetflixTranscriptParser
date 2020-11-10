# NetflixTranscriptParser
In order to use this, you first need to download the transcript you want to process from Netflix as an XML file.  Details of how to do that can be found on the following Reddit post,

https://www.reddit.com/r/netflix/comments/4i1sp7/all_guide_how_to_download_subtitles_from_netflix/

The resulting xml file will look something like this,

````
<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<tt xmlns:tt="http://www.w3.org/ns/ttml" xmlns:ttm="http://www.w3.org/ns/ttml#metadata" xmlns:ttp="http://www.w3.org/ns/ttml#parameter" xmlns:tts="http://www.w3.org/ns/ttml#styling" ttp:tickRate="10000000" ttp:timeBase="media" xmlns="http://www.w3.org/ns/ttml">
  <head>
    <ttp:profile use="http://netflix.com/ttml/profile/dfxp-ls-sdh"/>
    <styling>
      <style tts:backgroundColor="transparent" tts:textAlign="center" xml:id="style0"/>
      <style tts:color="white" tts:fontSize="100%" tts:fontWeight="normal" xml:id="style1"/>
      <style tts:color="white" tts:fontSize="100%" tts:fontStyle="italic" tts:fontWeight="normal" xml:id="style2"/>
    </styling>
    <layout>
      <region tts:displayAlign="after" xml:id="region0"/>
      <region tts:displayAlign="before" xml:id="region1"/>
    </layout>
  </head>
  <body>
    <div xml:space="preserve">
      <p begin="72155417t" end="96763334t" region="region0" style="style0" tts:extent="80.00% 80.00%" tts:origin="10.00% 10.00%" xml:id="subtitle0"><span style="style1">[presenter]</span><br/><span style="style2">She spent 20 years studying courage,</span></p>
      <p begin="97597500t" end="119702917t" region="region0" style="style0" tts:extent="80.00% 80.00%" tts:origin="10.00% 10.00%" xml:id="subtitle1"><span style="style2">vulnerability, shame, and empathy,</span></p>
      <p begin="120537084t" end="150150000t" region="region0" style="style0" tts:extent="80.00% 80.00%" tts:origin="10.00% 10.00%" xml:id="subtitle2"><span style="style2">wrote five </span><span style="style1">New York Times</span><br/><span style="style2">number one best sellers,</span></p>
      <p begin="150984167t" end="183516667t" region="region0" style="style0" tts:extent="80.00% 80.00%" tts:origin="10.00% 10.00%" xml:id="subtitle3"><span style="style2">and her TED Talk is one</span><br/><span style="style2">of the most watched in the world.</span></p>
...
````

Then, build the NetflixTranscriptParser solution included in this repository.  Run the dotnet core exectubale as below,

````
.\NetflixTranscriptParser.exe "C:\Files\transcript.xml" "C:\Files\formattedOutput.txt"
````

The result will yield a text file with the start timestamps of each closed caption text section.  Example below,

````
[00:00:07] [presenter] She spent 20 years studying courage,
[00:00:09] vulnerability, shame, and empathy,
[00:00:12] wrote five  New York Times number one best sellers,
[00:00:15] and her TED Talk is one of the most watched in the world.
[00:00:18] Please welcome Brené Brown.
...
````
