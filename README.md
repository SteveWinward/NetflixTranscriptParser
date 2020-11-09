# NetflixTranscriptParser
In order to use this, you first need to download the transcript you want to process from Netflix as an XML file.  Details of how to do that can be found on the following Reddit post,

https://www.reddit.com/r/netflix/comments/4i1sp7/all_guide_how_to_download_subtitles_from_netflix/

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
