/* SystemJS module definition */
declare var module: NodeModule;
interface NodeModule {
  id: string;
}

declare namespace starks {
  interface Student {
    id: number;
    firstName: string;
    lastName: string;
    gender: string;
    state: string;
    city: string;
    address: string;
    dateOfBirth: Date;
  }

  interface Mark {
    id: number;

  }

  interface Course {
    id : number;
    name: string;
    description: string;
  }

}
