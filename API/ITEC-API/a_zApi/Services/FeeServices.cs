using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
using a_zApi.IRepository;
using a_zApi.IServices;
using a_zApi.Repository;

namespace a_zApi.Services

{
    public class FeeServices: IFeeServices
    {
        private readonly lFeeRepository _ifeeRepository;
        public FeeServices(lFeeRepository ifeeRepository)
        {
            _ifeeRepository = ifeeRepository;
        }
        public async Task<FeeResponse> CreateFee(FeeRequest feeRequest)
        {
            var inputFee = new Fee();
            inputFee.StudentId = feeRequest.StudentId;
            inputFee.Name = feeRequest.Name;
            inputFee.MobileNo = feeRequest.MobileNo;
            inputFee.Dueamount = feeRequest.Dueamount;
            inputFee.Payamount = feeRequest.Payamount;
           // inputFee.Date = feeRequest.Date;//


            var addinputStudent = await _ifeeRepository.CreateFee(inputFee);

            var response = new FeeResponse();
            response.StudentId = inputFee.StudentId;
            response.Name = inputFee.Name;
            response.MobileNo = inputFee.MobileNo;
            response.Dueamount = feeRequest.Dueamount;
            response.Payamount = feeRequest.Payamount;
            response.Date = feeRequest.Date;

            return response;
        }
        public async Task<List<FeeResponse>> GetAllFee()
        {
            var data = await _ifeeRepository.GetAllFee();
            var response = new List<FeeResponse>();
            foreach (var fee in data)
            {
                var res = new FeeResponse();
                res.StudentId = fee.StudentId;
                res.Name = fee.Name;
                res.MobileNo = fee.MobileNo;
                res.Dueamount = fee.Dueamount;
                res.Payamount = fee.Payamount;
                res.Date = fee.Date;
                response.Add(res);
            }
            return response;
        }
        public async Task<FeeResponse> GetStudentById(string StudentId)
        {
            var data = await _ifeeRepository.GetFeeById(StudentId);
            var response = new FeeResponse();
            response.StudentId = data.StudentId;
            response.Name = data.Name;
            response.MobileNo = data.MobileNo;
            response.Dueamount = data.Dueamount;
            response.Payamount = data.Payamount;
            response.Date = data.Date;
            return response;

        }
        public async Task<FeeResponse> DeleteFeeById(string StudentId)
        {
            var data = await _ifeeRepository.DeleteFeeById(StudentId);
            var response = new FeeResponse();
            response.StudentId = data.StudentId;
            response.Name = data.Name;
            response.MobileNo = data.MobileNo;
            response.Dueamount = data.Dueamount;
            response.Payamount = data.Payamount;
           response.Date = data.Date
            return response;
        }
        public async Task<FeeResponse> UpdateStudent(string StudentId, FeeRequest feeRequest)
        {
            var data = await _ifeeRepository.FindFeeById(StudentId);
            if (data == null)
            {
                return null;
            }
            data.StudentId = feeRequest.StudentId;
            data.Name = feeRequest.Name;
            data.MobileNo = feeRequest.MobileNo;
            data.Dueamount = feeRequest.Dueamount;
            data.Payamount = feeRequest.Payamount;
            data.Date = feeRequest.Date;

            var updatedFee = await _ifeeRepository.UpdateFee(data);
            if (updatedFee == null)
            {
                return null;
            }

            var response = new FeeResponse
            {
                StudentId = updatedFee.StudentId,
                Name = updatedFee.Name,
                MobileNo = updatedFee.MobileNo,
                Dueamount = updatedFee.Dueamount,
                Payamount = updatedFee.Payamount,
                Date = updatedFee.Date,

            };
            return response;
        }
    }
}
