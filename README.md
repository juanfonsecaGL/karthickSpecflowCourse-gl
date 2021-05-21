# karthickSpecflowCourse-gl
Repository for uploading the artifact generated while testing https://gorillalogic.udemy.com/course/api-testing-with-restsharp-and-specflow-in-csharp

# Requisites:

On the NuGet packages manager:
* Specflow 
* Speclow.Assist
* Rest assure

Json server:
* Install: `npm install -g json-server`
* Start: `json-server ./db.json`
* Available endpoints:

```
http://localhost:3000/posts/1
http://localhost:3000/comments/1
http://localhost:3000/profile/1
```

Gherkin reference:
	* https://docs.specflow.org/projects/specflow/en/latest/Gherkin/Gherkin-Reference.html

To fix error with specflow:
* https://specflow.org/blog/changes-to-the-specflow-visual-studio-extension/
* https://stackoverflow.com/questions/65345910/error-specflow-designer-codebehind-generation-is-not-compatible-with-msbuild-c
