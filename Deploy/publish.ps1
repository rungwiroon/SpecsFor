import-module .\extensions\psake.psm1
import-module .\extensions\pscx
invoke-psake -taskList Publish,Archive
remove-module pscx
remove-module psake