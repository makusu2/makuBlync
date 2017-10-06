import requests
#url = "https://wit.service-now.com/incident_list.do?sysparm_userpref_module=bf2c0383c0a801640128cbe631d11c4b&sysparm_query=active=true^assigned_toISEMPTY^EQ&sysparm_clear_stack=true&sysparm_clear_stack=true"
url = "https://witdev.service-now.com/navpage.do"
page = requests.get(url,auth=('maku','Hello123'))#So it's not accepting my credentials this way
pageText = page.text
with open("test.html","w") as textFile:
    textFile.write(pageText)