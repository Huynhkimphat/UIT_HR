#Project Variables
PROJECT_NAME ?= HR_UIT
ORG_NAME ?= HR_UIT
REPO_NAME ?= HR_UIT

.PHONY: migrations db

migrations:
	cd ./HR_UIT.Data && dotnet ef --startup-project ../HR_UIT.Web/ migrations add $(mname) && cd ..

db:
	cd ./HR_UIT.Data && dotnet ef --startup-project ../HR_UIT.Web/ database update && cd ..
