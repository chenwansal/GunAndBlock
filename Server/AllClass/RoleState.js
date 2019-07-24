class RoleState {
    
    constructor() {

        // 战前相关
        this.sid = "";

        this.username = "";

        this.roleName = "";

        this.level = 1;

        this.exp = 0;

        this.rank = 0;

        this.score = 0;

        this.gold = 0;

        this.inServerId = -1;

        this.inComparingMode = -1;

        // 战斗时相关（不会存入数据库）
        this.inFieldId = -1;

        this.lifeOrigin = 5.0;

        this.life = 5.0;

        this.blockLifeOrigin = 3.0;
        
        this.blockLife = 3.0;

        this.damageOrigin = 1.0;
        
        this.damage = 1.0;
        
        this.shootGapOrigin = 1.0;
        
        this.shootGap = 0.0;
        
        this.blockGapOrigin = 0.5;
        
        this.blockGap = 0.0;
        
        this.perfectBlockLastOrigin = 0.2;
        
        this.perfectBlockLast = 0.0;
        
        this.moveSpeedOrigin = 2.0;
        
        this.moveSpeed = 2.0;

        this.shootSpeedOrigin = 4.0;
        
        this.shootSpeed = 4.0;

        this.vecArray = [0, 0];

        this.isLeftAlly = true;
        
        this.isBlocking = false;
        
        this.isPerfectBlocking = false;
        
        this.isMoving = false;
        
        this.isReloading = false;
        
        this.isDead = false; 

    }
}

module.exports = RoleState;