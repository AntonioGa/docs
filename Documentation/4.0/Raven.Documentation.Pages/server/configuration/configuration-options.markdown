# Server Configuration
RavenDB is **Safe by Default** which means its set of options are configured for best safe.  However these options can be manually configured in order to provide different server behavior.

## Setting Config Options
There are few ways to configure option values before initiating new server's instance.

### Environment Variable
Setting environment variable with the following sytax will set a configuration value.
Usage:
 `RAVEN_<ConfigOption>` or `RAVEN.<ConfigOption>`

Example:
```
export RAVEN_Setup.Mode=None
```

### settings.json
On the server executable directory lies `setting.json` which will be read and applied on server startup. 
Usage : `"ConfigOption": "ConfigValue"`

Example : 
```
{
    "ServerUrl": "http://127.0.0.1:8080",
    "Setup.Mode": "None"
}
```

*** setting.json config options OVERRIDES environment variables settings***

### Command Line Arguments
The Raven.Server executable can configure options using arguments which can be passed to the console application (or while running as daemon)
Usage: --<ConfigOption>=<ConfigValue>

Example:
```
./Raven.Server --Setup.Mode=None
```

*** Executable arguments config options OVERRIDES environment variables settings and setting.json***

