param location string = resourceGroup().location
param webContainerHost string

resource frontDoorProfile 'Microsoft.Cdn/profiles@2025-06-01' = {
  location: location
  name: webContainerHost // Used as simplified example
  sku: {
    name: 'Standard_AzureFrontDoor'
  }
}
