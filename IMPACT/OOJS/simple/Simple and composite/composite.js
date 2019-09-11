function Mobile(name) {
    this.name = name;
}

Mobile.prototype.display = function () {
    console.log(this.name);
}

function Device(name) {
    this.name = name;
    this.mobiles = [];
}

Device.prototype.add = function (mobile) {
    this.mobiles.push(mobile);
}

Device.prototype.getMobileName = function (index) {
    return this.mobiles[index].name;
}

Device.prototype.display = function() {
    console.log(this.name);
    for (let i = 0, length = this.mobiles.length; i < length; i++) {
        console.log("   ", this.getMobileName(i));
    }
}

Device1 = new Device('First device set');
Device2 = new Device('Second device set');

mob1 = new Mobile('Samsung');
mob2 = new Mobile('Oppo');
mob3 = new Mobile('One Plus');

Device1.add(mob1);
Device1.add(mob2);

Device2.add(mob1);
Device2.add(mob3);

Device1.display();
Device2.display();