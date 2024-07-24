export class Department{
    
    constructor(id:number, name:string, numberOfStudents:number){
        this._id = id;
        this._name = name;
        this._numberOfStudents = numberOfStudents;
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
    
    private _numberOfStudents : number;
    public get numberOfStudents() : number {
        return this._numberOfStudents;
    }
    public set numberOfStudents(v : number) {
        this._numberOfStudents = v;
    }
    
}