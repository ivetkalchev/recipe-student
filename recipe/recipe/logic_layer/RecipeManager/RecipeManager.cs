using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.RecipeManager
{
    public class RecipeManager
    {
        private RecipeApprovalService approvalService;
        private RecipeSubmissionService submissionService;
        private RecipeEditingService editingService;

        public RecipeManager(IRecipeValidator validator)
        {
            approvalService = new RecipeApprovalService(validator);
            submissionService = new RecipeSubmissionService();
            editingService = new RecipeEditingService();
        }
    }
}
