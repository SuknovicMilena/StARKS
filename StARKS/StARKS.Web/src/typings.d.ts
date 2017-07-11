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
    studentId: number;
    courseCode: number,
    markValue: number

  }

  interface Course {
    code : number;
    name: string;
    description: string;
  }

}
