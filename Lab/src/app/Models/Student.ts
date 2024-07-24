export class Student{
    constructor(id: number, name: string, trackName:string){
        this._id = id;
        this._name = name;
        this._trackName = trackName;
    }
    private _id : number;
    public get id() : number {
        return this._id;
    }
    public set id(v : number) {
        this._id = v;
    }
    
    private _name : string;
    public get name() : string {
        return this._name;
    }
    public set name(v : string) {
        this._name = v;
    }
    
    private _trackName : string;
    public get trackName() : string {
        return this._trackName;
    }
    public set trackName(v : string) {
        this._trackName = v;
    }
    
}