import { TaskCard } from "./task-card"

export interface TaskList {
    Listid: string
    Name: string
    TaskCards: TaskCard[]
}
