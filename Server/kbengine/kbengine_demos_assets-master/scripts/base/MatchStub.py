import KBEngine
from KBEDebug import *
from interfaces.GameObject import GameObject

class MatchStub(KBEngine.Entity, GameObject):
    """
    匹配中心点
    """
    def __init__(self):
        KBEngine.Entity.__init__(self)
        GameObject.__init__(self)
        KBEngine.globalData["MatchStub"] = self

    def reqJoinMatch(self, avatarEntity):
        """
        请求加入匹配
        """
        pass

    def reqQuitMatch(self, avatarEntity):
        """
        退出匹配
        """
        pass