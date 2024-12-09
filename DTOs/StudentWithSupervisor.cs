namespace ThesisMate.DTOs{
    public record StudentWithSupervisor(
        int StudentId, 
        string StudentName,
        string StudentEmail, 
        int SupervisorId, 
        string SupervisorName,
        bool HasSupervisor
    );
}