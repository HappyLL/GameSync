import KBEngine
from KBEDebug import *
from interfaces.GameObject import GameObject

class Hall(KBEngine.Entity, GameObject):
    """
    大厅
    """
    def __init__(self):
        KBEngine.Entity.__init__(self)
        GameObject.__init__(self)
        self.avatarEntities = {}

        KBEngine.globalData["Hall"] = self
    
    def loginToHall(self, avatarEntity):
        DEBUG_MSG("[Hall] Avatar %s login Hall"%avatarEntity.id)

    def logoutHall(self, avatarID):
        DEBUG_MSG("[Hall] Avatar %s logout Hall"%avatarID)
